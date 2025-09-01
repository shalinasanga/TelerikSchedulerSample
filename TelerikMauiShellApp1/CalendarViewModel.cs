
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Telerik.Maui.Controls;

namespace TelerikMauiShellApp1
{
    public class CalendarViewModel : ViewModelBase
    {
        private ResourceManager resourceManager;
        System.Globalization.Calendar callendar;
        private AppTheme currentTheme = Application.Current.RequestedTheme;
        public CalendarViewModel()
        {
            resourceManager = new ResourceManager(typeof(AppResources));
            callendar = CultureInfo.CurrentUICulture.Calendar;
        }
        private ObservableCollection<DetailEventModel> _EventListForCal =
          new ObservableCollection<DetailEventModel>();
        public ObservableCollection<DetailEventModel> EventListForCal { get; set; } = new ObservableCollection<DetailEventModel>();
        private ViewDefinitionBase _CalendarMode;
        public ViewDefinitionBase CalendarMode
        {
            get { return _CalendarMode; }
            set
            {
                if (_CalendarMode != value)
                {
                    _CalendarMode = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _CalendarModeIndex = UserProfileSettings.LastSelectedCalendarView.HasValue ?
           UserProfileSettings.LastSelectedCalendarView.Value : 0;
        public int CalendarModeIndex
        {
            get { return _CalendarModeIndex; }
            set
            {
                if (_CalendarModeIndex != value)
                {
                    _CalendarModeIndex = value;
                    OnPropertyChanged();
                    _ = GetEvents();
                    Task.Run(() =>
                    {
                        UserProfileSettings.LastSelectedCalendarView = value;
                        SecureStorage.Default.SetAsync(Constants.LastSelectedCalendarView, value.ToString());
                    });
                }
            }
        }
        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged();
                    UserProfileSettings.LastSelectedCalendarDate = value;
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        _ = GetEvents();
                    });
                }
            }
        }
        private ObservableCollection<DetailEventModel> _InitialTidEventList = new ObservableCollection<DetailEventModel>();
        public ObservableCollection<DetailEventModel> InitialTidEventList
        {
            get { return _InitialTidEventList; }
            set
            {
                _InitialTidEventList = value;
                OnPropertyChanged();
            }
        }
        List<ResourceItemModel> FavouriteResources { get; set; }
        List<Guid> FavouriteLabelList { get; set; }
        private ObservableCollection<DetailEventModel> _InitialEventList = new ObservableCollection<DetailEventModel>();
        public ObservableCollection<DetailEventModel> InitialEventList
        {
            get { return _InitialEventList; }
            set
            {
                _InitialEventList = value;
                OnPropertyChanged();
            }
        }
        private string _WeekHeader;
        public string WeekHeader
        {
            get { return _WeekHeader; }
            set
            {
                _WeekHeader = value;
                OnPropertyChanged();
            }
        }
        private DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            var cultureInfo = CultureInfo.CurrentUICulture;
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }
            return firstDayInWeek;
        }
        private DateTime startDate;
        private DateTime endDate;
        public async Task GetEvents()
        {
            try
            {
                if (IsBusy || SelectedDate == DateTime.MinValue) /*|| (SelectedDate > startDate && SelectedDate < endDate)*/
                {
                    return;
                }
                IsBusy = true;
                if (CalendarModeIndex == 0)//Week view
                {
                    startDate = GetFirstDayOfWeek(SelectedDate);
                    endDate = SelectedDate.AddDays(7);
                    CalendarHeaderText();
                }
                else if (CalendarModeIndex == 1)//MultiDay view - 3 days for now
                {
                    startDate = SelectedDate;
                    endDate = SelectedDate.AddDays(3);
                    CalendarHeaderText();
                }
                else if (CalendarModeIndex == 2)//Day view
                {
                    startDate = SelectedDate;
                    endDate = SelectedDate.AddDays(1);
                    // CalendarHeaderText();
                }
                else//Month view
                {
                    startDate = new DateTime(SelectedDate.Year, SelectedDate.Month, 1);
                    endDate = startDate.AddMonths(1).AddDays(-1);
                }

              GenerateRandomEvents(5);


                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Schduler", ex.Message, "OK");
            }
        }
        private void CalendarHeaderText()
        {
            WeekHeader = startDate.Date.Day + " ~ " + endDate.Date.Day + " " +
                                    startDate.ToString("MMMM") + " " + startDate.Year.ToString() +
                                    " (" + resourceManager.GetString("CALENDAR_VIEW_WEEK", CultureInfo.CurrentUICulture) + " " +
                                    callendar.GetWeekOfYear(SelectedDate, CultureInfo.CurrentUICulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek) +
                                    ")";
        }
        private void GenerateRandomEvents(int eventCount = 10)
        {
            var random = new Random();
            EventListForCal.Clear();
            string backgroundTint = "#FFFF";
            for (int i = 0; i < eventCount; i++)
            {
                if (currentTheme == AppTheme.Dark)
                {
                    // Apply dark theme specific logic
                    //< Color x: Key = "Gray500" >#6E6E6E</Color>
                    backgroundTint = "#6E6E6E";
                }
                else // AppTheme.Light
                {
                    // Apply light theme specific logic
                    //< Color x: Key = "CalendarAppointmentBackground" >#f5f6f6</Color>
                    backgroundTint = "#f5f6f6";
                }
                // Generate random labels
                int labelCount = random.Next(1, 4);
                var labels = new List<EventLabelModel>();
                for (int j = 0; j < labelCount; j++)
                {
                    string hex = RandomHexColor();
                    labels.Add(new EventLabelModel
                    {
                        LabelId = Guid.NewGuid(),
                        LabelCaption = $"Label {j + 1}",
                        LabelColor = random.Next(0x1000000),
                        HexColor = hex
                    });
                }
                if (labels.Count > 0)
                {
                    backgroundTint = Color.FromArgb(labels.First().HexColor).MultiplyAlpha(0.20f).ToArgbHex();
                }
                // Generate a random date within the range
                int range = (endDate - startDate).Days;
                DateTime start = startDate.AddDays(random.Next(range + 1))
                                              .AddHours(random.Next(0, 24))
                                              .AddMinutes(random.Next(0, 60));
                // Random duration between 30 and 180 minutes
                int durationMinutes = random.Next(30, 181);
                DateTime end = start.AddMinutes(durationMinutes);
                Guid OccurenceID = Guid.NewGuid();
                var evt = new DetailEventModel
                {
                    Subject= $"Random Event {i + 1}",
                    Start = start,
                    End = end,
                    //EventMessage = $"Random Event {i + 1}",
                    //DateString = start.ToString("yyyy-MM-dd"),
                    //TimeString = start.ToString("HH:mm"),
                    EventLableList = labels,
                    OccurenceID = OccurenceID,

                    Detail = OccurenceID.ToString(),//Need this to get Normal Appointment template from template selector

                    //ReminderDate = start.AddMinutes(-random.Next(5, 60)),
                    //IsPrivate = random.Next(0, 2) == 0,
                    //IsSpecialAttention = random.Next(0, 2) == 0,
                    //F_ContactID = Guid.NewGuid(),
                    //F_CreatedUser_ID = Guid.NewGuid(),
                    //IsPublished = random.Next(0, 2) == 0,
                    //Responsible = $"User {random.Next(1, 100)}",
                    //SelectedResourceID = Guid.NewGuid(),
                    BackgroundTintColor =backgroundTint,
                    //EventLabelColor = random.Next(0x1000000),
                    //EventStatusColor = random.Next(0x1000000),
                    //EventStatusDescription = "Random Status",
                    //EventStatusImageSource = "",
                    //HasReminder = random.Next(0, 2) == 0,
                    //HasAttachments = random.Next(0, 2) == 0,
                    //HasMissingResources = random.Next(0, 2) == 0,
                    //IsReccuringEvent = random.Next(0, 2) == 0,
                    //HasLink = random.Next(0, 2) == 0,
                    //IsProsteModulAppointment = random.Next(0, 2) == 0,
                    //HasEventMessage = random.Next(0, 2) == 0,
                    //IsIconListVisible = random.Next(0, 2) == 0,
                    //EventStatusColorHex = RandomHexColor(),
                    //EventPrimeLabelColorHex = RandomHexColor(),
                    //ItemType = random.Next(1, 5),
                    //EventTemplateID = Guid.NewGuid(),
                    //LableListWidth = random.Next(50, 200)
                };

                EventListForCal.Add(evt);
            }
        }

        private string RandomHexColor()
        {
            Random random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
    }
}
