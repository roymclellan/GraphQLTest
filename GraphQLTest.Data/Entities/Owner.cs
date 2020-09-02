using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLTest.Data.Entities
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
    }
}
