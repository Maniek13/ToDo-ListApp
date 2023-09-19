using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ToDoList.Interfaces;

namespace ToDoList.DbModels
{
    public record Reminder : IReminder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; } = "";
        [AllowNull]
        public int? TaskID { get; set; }
    }
}
