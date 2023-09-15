using System;

namespace ToDoList.Models
{
    internal struct Reminder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? TaskID { get; set; }
    }
}
