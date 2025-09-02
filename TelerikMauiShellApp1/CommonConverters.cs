using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class TextToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class StatusToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            if (value.ToString().Equals(Constants.StatusTempDescription))
            {
                return "ic_event_status_temp_red.png";
            }
            else if (value.ToString().Equals(Constants.StatusUnderPlanningDescription))
            {
                return "ic_event_status_planning_yellow.png";
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class TitleImageConverter : IValueConverter
    {
        private ResourceManager resourceManager = new ResourceManager(typeof(AppResources));
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            if (value.ToString() == resourceManager.GetString("TID_TYPE_PRESENT", culture))
            {
                return "ic_present.png";
            }
            else if (value.ToString() == resourceManager.GetString("TID_TYPE_ABSENCE", culture))
            {
                return "ic_absence.png";
            }
            else//TID_TYPE_ONDUTY
            {
                return "ic_onduty.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class TitleToColorConverter : IValueConverter
    {
        private ResourceManager resourceManager = new ResourceManager(typeof(AppResources));
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                return Color.FromArgb("#ffffff");
            }
            if (value.ToString() == resourceManager.GetString("TID_TYPE_PRESENT", culture))
            {
                return Color.FromArgb("#59a8e2");//"#596666FF";
            }
            else if (value.ToString() == resourceManager.GetString("TID_TYPE_ABSENCE", culture))
            {
                return Color.FromArgb("#f85454");
            }
            else//TID_TYPE_ONDUTY
            {
                return Color.FromArgb("#F68AC0");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class EventStatusToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            if (value.ToString().Equals(Constants.StatusTempDescription))
            {
                return true;
            }
            else if (value.ToString().Equals(Constants.StatusUnderPlanningDescription))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class ResourceNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var ContactId = (Guid)value;
            if (ContactId == Guid.Empty)
            {
                return UserProfileSettings.SelectedResource.Name;
            }
            if (ContactId == UserProfileSettings.PlannerContactId)
            {
                return AppResources.COMMON_MY_CALENDAR;
            }
            else
            {
                return UserProfileSettings.SelectedResource.Name;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
