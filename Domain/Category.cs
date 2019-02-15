using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required, MaxLength(32)]
        public string CategoryName { get; set; }

        public List<Todo> Todos { get; set; } = new List<Todo>();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}