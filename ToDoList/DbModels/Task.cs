using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.DbModels
{
    public record Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public int Type { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool HasReminder { get; set; } = false;
    }
}
