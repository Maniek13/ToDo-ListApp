using System;
using System.Linq;
using ToDoList.Helper;
using ToDoList.Interfaces;

namespace ToDoList.Models
{
    public struct Task : ITask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public bool HasReminder { get; set; }
        public DateTime EndDate { get; set; }

        public string GetColor
        {
            get
            {
                bool status = EndDate <= DateTime.Now ? true : false;
                return Resources.EndedStatusColor.Select(el => el).Where(el => el.Key == status).FirstOrDefault().Value;
            }
        }
        public Task()
        {
            EndDate = DateTime.Now;
        }
    }
}
