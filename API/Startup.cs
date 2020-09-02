using API.GraphQL.GraphQLSchema;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Entities = GraphQLTest.Data.Entities;
using Repositories = GraphQLTest.Domain;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<Entities.Context.ApplicationContext>(opt =>
                            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped<Repositories.Owner.IOwnerRepository, Repositories.Owner.OwnerRepository>();
            services.AddScoped<Repositories.Account.IAccountRepository, Repositories.Account.AccountRepository>();
            services.AddScoped<Repositories.Type.ITypeRepository, Repositories.Type.TypeRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<AppSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();

            ////////////////////////////////////////////////////////////////////////////////
            //                                                                            //
            //   This is the line that allows GraphiQL Playground to work in .Net Core v3 //
            //                                                                            //
            ////////////////////////////////////////////////////////////////////////////////
            services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });

            services.AddMvc()
                .AddNewtonsoftJson(opts => opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
