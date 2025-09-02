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
        public static ResourceItemModel SelectedResource { get; set; }
        public static Guid PlannerContactId { get; set; } = Guid.NewGuid();
        public static Guid PlannerUserId { get; set; } = new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301");
    }
}
