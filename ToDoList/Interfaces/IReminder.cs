using System;

namespace ToDoList.Interfaces
{
    internal interface IReminder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? TaskID { get; set; }
    }
}
