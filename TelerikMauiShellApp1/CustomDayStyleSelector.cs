using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Maui.Controls.Scheduler;

namespace TelerikMauiShellApp1
{
    public class CustomDayStyleSelector : DayStyleSelector
    {
        private Style customNormalStyle;
        private Style customTodayStyle;
        private Style weekendLabelStyle;

        public override Style SelectStyle(object item, BindableObject bindable)
        {
            var node = (DateNode)item;
            if (node.IsToday)
            {
                return this.customTodayStyle;
            }

            var date = node.Date;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return this.weekendLabelStyle;
            }

            return this.customNormalStyle;
        }

        public Style CustomNormalStyle
        {
            get => this.customNormalStyle;
            set
            {
                this.customNormalStyle = value;
                this.customNormalStyle.BasedOn = this.NormalLabelStyle;
            }
        }

        public Style CustomTodayStyle
        {
            get => this.customTodayStyle;
            set
            {
                this.customTodayStyle = value;
                this.customTodayStyle.BasedOn = this.TodayLabelStyle;
            }
        }

        public Style WeekendLabelStyle
        {
            get => this.weekendLabelStyle;
            set
            {
                this.weekendLabelStyle = value;
                this.weekendLabelStyle.BasedOn = this.NormalLabelStyle;
            }
        }
    }
}
