using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Maui.Controls.Scheduler;

namespace TelerikMauiShellApp1
{
    public class AppointmentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AllDay { get; set; }
        public DataTemplate NormalAppointment { get; set; }
        public DataTemplate TID { get; set; }
        public DataTemplate XBridge { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //var appointmentsTemplate = item as DetailEventModel;
            var appointmentsTemplate = (item as AppointmentNode).Occurrence.Appointment as DetailEventModel;

            if (appointmentsTemplate.IsAllDay)
            {
                return this.AllDay;
            }
            else if (appointmentsTemplate.Detail == "Tid")
            {
                return this.TID;
            }
            else if (appointmentsTemplate.Detail == appointmentsTemplate.OccurenceID.ToString())
            {
                return this.NormalAppointment;
            }
            return this.XBridge;
        }
    }
}
