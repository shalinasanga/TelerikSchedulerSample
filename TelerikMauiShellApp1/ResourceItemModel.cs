using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class ResourceItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public ResourceTypeDTO ResourceType { get; set; }
        public string ImageSource { get; set; }
        public bool IsCannotPlan { get; set; }
    }

    public class GoToAppointmentView
    {
        public List<ResourceItemModel> ResourcesList { get; set; }

        public List<StaffFunctionModel> FunctionsList { get; set; }

        public GoToAppointmentView()
        {
            ResourcesList = new List<ResourceItemModel>();
            FunctionsList = new List<StaffFunctionModel>();
        }
    }
}
