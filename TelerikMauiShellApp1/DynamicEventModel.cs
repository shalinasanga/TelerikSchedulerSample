using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public class DynamicEventModel : INotifyPropertyChanged
    {
        public Guid PK_EventID { get; set; }
        public Guid OccurenceID { get; set; }
        public Guid EventLabelColorID { get; set; }
        public int TempResId { get; set; }
        public int EventOptions { get; set; }
        public int OffSetStart { get; set; }
        public int OffSetEnd { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Color Color { get; set; }
        public string Detail { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsStatCodeAdded { get; set; }
        public int EventLabelColor { get; set; }
        public string LocationCaption { get; set; }
        public DateTime ReminderDate { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsSpecialAttention { get; set; }
        public Guid F_ContactID { get; set; }
        public Guid F_CreatedUser_ID { get; set; }
        public bool IsPublished { get; set; }
        public string Responsible { get; set; }
        public Guid SelectedResourceID { get; set; }
        public List<EventLabelModel> EventLableList { get; set; }
        public Dictionary<int, EventLabelModel> LabelsDictionary { get; set; }
        public bool HasAttachments { get; set; }
        public Guid LinkId { get; set; }
        public bool HasMissingResources { get; set; }
        public int EventStatusColor { get; set; }
        public int? RemindMinutesBefore { get; set; }
        public bool HasReminder { get; set; }
        public bool IsPublishedToSognDK { get; set; }
        private string _EventStatusDescription;
        public string EventStatusDescription
        {
            get { return _EventStatusDescription; }
            set
            {
                _EventStatusDescription = value;
                NotifyPropertyChanged();
                SetStatusIcon(value);
            }
        }
        private string _EventStatusImageSource;
        public string EventStatusImageSource
        {
            get { return _EventStatusImageSource; }
            set
            {
                _EventStatusImageSource = value;
                NotifyPropertyChanged();
            }
        }
        private string _EventMessage;
        public string EventMessage
        {
            get { return _EventMessage; }
            set
            {
                _EventMessage = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsReccuringEvent { get; set; }
        public bool HasLink { get; set; }
        public bool IsProsteModulAppointment { get; set; }
        private bool _HasEventMessage;
        public bool HasEventMessage
        {
            get { return _HasEventMessage; }
            set
            {
                _HasEventMessage = value;
                NotifyPropertyChanged();
            }
        }

        public EventLabelModel PrimeLabel { get; set; }
        public bool IsIconListVisible { get; set; }
        public string EventStatusColorHex { get; set; }
        public string TimeString { get; set; }
        public string DateString { get; set; }
        public ResourceItemModel SelectedResource { get; set; }
        public StatStatusEnum StatStatus { get; set; }
        public bool IsXbridgeAppointment { get; set; }
        public string EventPrimeLabelColorHex { get; set; }
        public int ItemType { get; set; }
        public ImageSource TidImgSource { get; set; }
        public Color TidColor { get; set; }
        public Guid EventTemplateID { get; set; }
        public int LabelListWidth { get; set; }
        private string _BackgroundTintColor;
        public string BackgroundTintColor
        {
            get { return _BackgroundTintColor; }
            set
            {
                _BackgroundTintColor = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        protected void SetStatusIcon(string eventDescription)
        {
            try
            {
                ResourceManager rm = new ResourceManager("Medarbeideren.Resx.AppResources", typeof(AppResources).Assembly);
                var translatedEventDescription = rm.GetString(eventDescription, CultureInfo.InvariantCulture);
                switch (translatedEventDescription)
                {
                    case "Confirmed":
                        EventStatusImageSource = "ic_confirmed_circle.png";
                        break;
                    case "Temporary":
                        EventStatusImageSource = "ic_temporary_triangel.png";
                        break;
                    case "Under planning":
                        EventStatusImageSource = "ic_underplaning_rectangle.png";
                        break;
                    default:
                        EventStatusImageSource = "ic_planing_cancel.png";
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
