using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class UserProfileSettings
    {
        public static int? LastSelectedCalendarView { get; set; }
        public static DateTime LastSelectedCalendarDate { get; set; } = DateTime.Now;
        public static int StartWorkingHours { get; set; } = 9;
    }
}
