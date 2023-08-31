using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Helper
{
    internal class Resources
    {
        public static Dictionary<string, int> TaskTypes = new ()
        {
            {"Proprity", 1},
            {"Casual", 2}
        };
    }
}
