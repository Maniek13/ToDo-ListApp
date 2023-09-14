using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
        [AllowNull]
        public int? TaskID { get; set; }
    }
}
