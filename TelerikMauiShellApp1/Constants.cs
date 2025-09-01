using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public static class Constants
    {
        //Appointment description translation keys
        public static readonly string StatusTempDescription = "CAL_FILTER_EVENTSTATUS_TEMPORARY";
        public static readonly string StatusUnderPlanningDescription = "CAL_FILTER_EVENTSTATUS_UNDERPLANNING";
        //Cache Keys 
        public const string AuthInfo = "AuthInfo";
        public const string SelectedContext = "SelectedContext";
        public const string RecentCalendars = "RecentCalendars";
        public const string ShowTidSetting = "ShowTidSetting";
        public const string LastSelectedCalendarView = "LastSelectedCalendarView";

        //Secure storage cache keys
        public const string UserApplicationId = "user_application_id";
        public const string OpenId = "medarbeideren_open_id";
        public const string IsLoggedIn = "medarbeideren_is_logged_in";
        public const string TokenExpirationTime = "medarbeideren_token_expiration_time";
        public const string RefreshToken = "refreshtoken";
        public const string AccessToken = "accesstoken";
        public const string IdentityToken = "identitytoken";
        public const string PushDeviceToken = "medarbeideren_device_token";
        public const string IsNewPushDeviceToken = "medarbeideren_is_new_push_device_token";
        public const string IsBioMetricEnabled = "IsBioMetricEnabled";
        public const string IsUserAuthBiometric = "IsUserAuthBiometric";
    }
}
