﻿using ToDoList.Interfaces;

namespace ToDoList.Models
{
    public struct Task : ITask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}
