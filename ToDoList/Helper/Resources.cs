using System.Collections.Generic;

namespace ToDoList.Helper
{
    internal class Resources
    {
        public static Dictionary<string, int> TaskTypes = new()
        {
            {"Prority", 1},
            {"Casual", 2}
        };


        public static Dictionary<bool, string> EndedStatusColor = new Dictionary<bool, string>()
        {
            { true , "red"},
            { false, "green" }
        };
    }
}
