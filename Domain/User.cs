using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        
        [Required, MaxLength(16)]
        public string UserName { get; set; }

        public List<Todo> Todos { get; set; } = new List<Todo>();

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}