using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Todo
    {
        public int TodoId { get; set; }
        
        [Required, MaxLength(32)]
        public string HeadLine { get; set; }
        [Required, MaxLength(256)]
        public string Description { get; set; }
        
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime DueDate { get; set; }

        public bool Done { get; set; } = false;

        public Priority Priority { get; set; } = Priority.Medium;

        public int PriorityNo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}