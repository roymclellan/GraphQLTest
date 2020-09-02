using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLTest.Data.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public int TypeId { get; set; }
        public string Description { get; set; }

        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
