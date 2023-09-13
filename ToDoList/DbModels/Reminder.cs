using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.DbModels
{
    internal record Reminder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; } = "";
    }
}
