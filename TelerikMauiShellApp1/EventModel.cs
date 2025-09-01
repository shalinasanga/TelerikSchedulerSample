using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Maui.Controls.Scheduler;

namespace TelerikMauiShellApp1
{
    public enum CloseMode
    {
        Cancel,
        Save,
        Edit
    }
    public class EventModel : Telerik.Maui.Controls.Scheduler.Appointment
    {
        private Guid _PK_EventID;
        public Guid PK_EventID
        {
            get => this._PK_EventID;
            set => this.UpdateValue(ref this._PK_EventID, value);
        }
        private Guid _OccurenceID;
        public Guid OccurenceID
        {
            get => this._OccurenceID;
            set => this.UpdateValue(ref this._OccurenceID, value);
        }
        private Guid _EventLabelColorID;
        public Guid EventLabelColorID
        {
            get => this._EventLabelColorID; set => this.UpdateValue(ref this._EventLabelColorID, value);
        }
        private int _TempResId;
        public int TempResId
        {
            get => this._TempResId; set => this.UpdateValue(ref this._TempResId, value);
        }
        private int _EventOptions;
        public int EventOptions
        {
            get => this._EventOptions;
            set => this.UpdateValue(ref this._EventOptions, value);
        }
        private int _OffSetStart;
        public int OffSetStart
        {
            get => this._OffSetStart; set => this.UpdateValue(ref this._OffSetStart, value);
        }
        private int _OffSetEnd;
        public int OffSetEnd
        {
            get => this._OffSetEnd; set => this.UpdateValue(ref this._OffSetEnd, value);
        }
        //These are mantatory fileds for Telerik 
        //so these are used for Subjetct,Start date and end date
        // private string _Title;
        [Obsolete("Use Subject instead")]
        public string Title { get; set; }
        [Obsolete("Use Start instead")]
        public DateTime StartDate { get; set; }
        [Obsolete("Use End instead")]
        public DateTime EndDate { get; set; }
        private Color _Color;
        public Color Color
        {
            get => this.Color; set => this.UpdateValue(ref this._Color, value);
        }
        private string _Detail;
        public string Detail
        {
            get => this._Detail;
            set => this.UpdateValue(ref this._Detail, value);
        }
        //Use Telerik Appointment members for below properties
        // public bool IsAllDay { get; set; }
        //  public event EventHandler RecurrenceRuleChanged;
        //End of- Use Telerik Appointment members for below properties
        private bool _IsStatCodeAdded;
        public bool IsStatCodeAdded
        {
            get => this._IsStatCodeAdded; set => this.UpdateValue(ref this._IsStatCodeAdded, value);
        }
        //Telerik MAUI mandatory fields, use these from Telerik Appointment - start
        //public DateTime End { get; set; }
        //public DateTime Start { get; set; }
        //public IRecurrenceRule RecurrenceRule { get; set; }
        //public string Subject { get; set; }
        //public TimeZoneInfo TimeZone { get; set; }
        //Telerik MAUI mandatory fields - end
        //public event PropertyChangedEventHandler PropertyChanged;


        //public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    if (PropertyChanged == null)
        //        return;
        //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
        public override IAppointment Copy()
        {
            var eventModel = new EventModel();
            eventModel.CopyFrom(this);
            return eventModel;
        }

        public override void CopyFrom(IAppointment other)
        {
            var eventModel = other as EventModel;
            if (eventModel != null)
            {
                this.PK_EventID = eventModel.PK_EventID;
                this.OccurenceID = eventModel.OccurenceID;
                this.EventLabelColorID = eventModel.EventLabelColorID;
                this.TempResId = eventModel.TempResId;
                this.EventOptions = eventModel.EventOptions;
                this.OffSetStart = eventModel.OffSetStart;
                this.OffSetEnd = eventModel.OffSetEnd;
                this.Color = eventModel.Color;
                this.Detail = eventModel.Detail;
                this.IsStatCodeAdded = eventModel.IsStatCodeAdded;
            }
            base.CopyFrom(other);
        }
    }

    public class DetailEventModel : EventModel
    {
        private int _EventLabelColor;
        public int EventLabelColor
        {
            get => this._EventLabelColor;
            set => this.UpdateValue(ref this._EventLabelColor, value);
        }
        private string _BackgroundTintColor;
        public string BackgroundTintColor
        {
            get => this._BackgroundTintColor;
            set => this.UpdateValue(ref this._BackgroundTintColor, value);
        }
        private string _LocationCaption;
        public string LocationCaption
        {
            get => this._LocationCaption;
            set => this.UpdateValue(ref this._LocationCaption, value);
        }
        private DateTime _ReminderDate;
        public DateTime ReminderDate
        {
            get => this._ReminderDate; set => this.UpdateValue(ref this._ReminderDate, value);
        }
        private bool _IsPrivate;
        public bool IsPrivate
        {
            get => this._IsPrivate; set => this.UpdateValue(ref this._IsPrivate, value);
        }
        private bool _IsSpecialAttention;
        public bool IsSpecialAttention
        {
            get => this._IsSpecialAttention; set => this.UpdateValue(ref this._IsSpecialAttention, value);
        }
        private Guid _F_ContactID;
        public Guid F_ContactID
        {
            get => this._F_ContactID; set => this.UpdateValue(ref this._F_ContactID, value);
        }
        private Guid _F_CreatedUser_ID;
        public Guid F_CreatedUser_ID
        {
            get => this._F_CreatedUser_ID; set => this.UpdateValue(ref this._F_CreatedUser_ID, value);
        }
        private bool _IsPublished;
        public bool IsPublished
        {
            get => this._IsPublished; set => this.UpdateValue(ref this._IsPublished, value);
        }
        private string _Responsible;
        public string Responsible
        {
            get => this._Responsible; set => this.UpdateValue(ref this._Responsible, value);
        }
        private Guid _SelectedResourceID;
        public Guid SelectedResourceID
        {
            get => this._SelectedResourceID; set => this.UpdateValue(ref this._SelectedResourceID, value);
        }
        private List<EventLabelModel> _EventLableList = new List<EventLabelModel>();
        public List<EventLabelModel> EventLableList
        {
            get => this._EventLableList; set => this.UpdateValue(ref this._EventLableList, value);
        }
        private Dictionary<int, EventLabelModel> _LabelsDictionary = new Dictionary<int, EventLabelModel>();
        public Dictionary<int, EventLabelModel> LabelsDictionary
        {
            get => this._LabelsDictionary; set => this.UpdateValue(ref this._LabelsDictionary, value);
        }
        private bool _HasAttachments;
        public bool HasAttachments
        {
            get => this._HasAttachments; set => this.UpdateValue(ref this._HasAttachments, value);
        }
        private Guid _LinkId;
        public Guid LinkId
        {
            get => this._LinkId; set => this.UpdateValue(ref this._LinkId, value);
        }
        private bool _HasMissingResources;
        public bool HasMissingResources
        {
            get => this._HasMissingResources; set => this.UpdateValue(ref this._HasMissingResources, value);
        }
        private int _EventStatusColor;
        public int EventStatusColor
        {
            get => this._EventStatusColor; set => this.UpdateValue(ref this._EventStatusColor, value);
        }
        private int? _RemindMinutesBefore;
        public int? RemindMinutesBefore
        {
            get => this._RemindMinutesBefore; set => this.UpdateValue(ref this._RemindMinutesBefore, value);
        }
        private bool _HasReminder;
        public bool HasReminder
        {
            get => this._HasReminder; set => this.UpdateValue(ref this._HasReminder, value);
        }
        private bool _IsPublishedToSognDK;
        public bool IsPublishedToSognDK
        {
            get => this._IsPublishedToSognDK; set => this.UpdateValue(ref this._IsPublishedToSognDK, value);
        }
        private string _EventStatusDescription;
        public string EventStatusDescription
        {
            get => this._EventStatusDescription; set => this.UpdateValue(ref this._EventStatusDescription, value);
        }
        private string _EventStatusImageSource;
        public string EventStatusImageSource
        {
            get => this._EventStatusImageSource; set => this.UpdateValue(ref this._EventStatusImageSource, value);
        }
        private string _EventMessage;
        public string EventMessage
        {
            get => this._EventMessage; set => this.UpdateValue(ref this._EventMessage, value);
        }
        private bool _IsReccuringEvent;
        public bool IsReccuringEvent
        {
            get => this._IsReccuringEvent; set => this.UpdateValue(ref this._IsReccuringEvent, value);
        }
        private bool _HasLink;
        public bool HasLink
        {
            get => this._HasLink; set => this.UpdateValue(ref this._HasLink, value);
        }
        private bool _IsProsteModulAppointment;
        public bool IsProsteModulAppointment
        {
            get => this._IsProsteModulAppointment; set => this.UpdateValue(ref this._IsProsteModulAppointment, value);
        }
        private bool _HasEventMessage;
        public bool HasEventMessage
        {
            get => this._HasEventMessage; set => this.UpdateValue(ref this._HasEventMessage, value);
        }
        private EventLabelModel _PrimeLabel;
        public EventLabelModel PrimeLabel
        {
            get => this._PrimeLabel; set => this.UpdateValue(ref this._PrimeLabel, value);
        }
        private bool _IsIconListVisible;
        public bool IsIconListVisible
        {
            get => this._IsIconListVisible; set => this.UpdateValue(ref this._IsIconListVisible, value);
        }
        private string _EventStatusColorHex;
        public string EventStatusColorHex
        {
            get => this._EventStatusColorHex; set => this.UpdateValue(ref this._EventStatusColorHex, value);
        }
        private string _TimeString;
        public string TimeString
        {
            get => this._TimeString; set => this.UpdateValue(ref this._TimeString, value);
        }
        private string _DateString;
        public string DateString
        {
            get => this._DateString; set => this.UpdateValue(ref this._DateString, value);
        }
        private ResourceItemModel _SelectedResource;
        public ResourceItemModel SelectedResource
        {
            get => this._SelectedResource; set => this.UpdateValue(ref this._SelectedResource, value);
        }
        private StatStatusEnum _StatStatus;
        public StatStatusEnum StatStatus
        {
            get => this._StatStatus; set => this.UpdateValue(ref this._StatStatus, value);
        }
        private bool _IsXbridgeAppointment;
        public bool IsXbridgeAppointment
        {
            get => this._IsXbridgeAppointment; set => this.UpdateValue(ref this._IsXbridgeAppointment, value);
        }
        private string _EventPrimeLabelColorHex;
        public string EventPrimeLabelColorHex
        {
            get => this._EventPrimeLabelColorHex; set => this.UpdateValue(ref this._EventPrimeLabelColorHex, value);
        }
        private int _ItemType;
        public int ItemType
        {
            get => this._ItemType; set => this.UpdateValue(ref this._ItemType, value);
        }
        private ImageSource _TidImgSource;
        public ImageSource TidImgSource
        {
            get => this._TidImgSource; set => this.UpdateValue(ref this._TidImgSource, value);
        }
        private Color _TidColor;
        public Color TidColor
        {
            get => this._TidColor; set => this.UpdateValue(ref this._TidColor, value);
        }
        private Guid _EventTemplateID;
        public Guid EventTemplateID
        {
            get => this._EventTemplateID; set => this.UpdateValue(ref this._EventTemplateID, value);
        }
        private int _LableListWidth;
        public int LableListWidth
        {
            get => this._LableListWidth; set => this.UpdateValue(ref this._LableListWidth, value);
        }

        //public DetailEventModel()
        //{
        //    //EventLableList = new List<EventLabelModel>();
        //    //LabelsDictionary = new Dictionary<int, EventLabelModel>();
        //}
        public override IAppointment Copy()
        {
            var detailEvent = new DetailEventModel();
            detailEvent.CopyFrom(this);
            return detailEvent;
        }
        public override void CopyFrom(IAppointment other)
        {
            var detailEvent = other as DetailEventModel;
            if (detailEvent != null)
            {
                this.EventLabelColor = detailEvent.EventLabelColor;
                this.LocationCaption = detailEvent.LocationCaption;
                this.ReminderDate = detailEvent.ReminderDate;
                this.IsPrivate = detailEvent.IsPrivate;
                this.IsSpecialAttention = detailEvent.IsSpecialAttention;
                this.F_ContactID = detailEvent.F_ContactID;
                this.F_CreatedUser_ID = detailEvent.F_CreatedUser_ID;
                this.IsPublished = detailEvent.IsPublished;
                this.Responsible = detailEvent.Responsible;
                this.SelectedResource = detailEvent.SelectedResource;
                this.EventLableList = detailEvent.EventLableList;
                this.LabelsDictionary = detailEvent.LabelsDictionary;
                this.HasAttachments = detailEvent.HasAttachments;
                this.LinkId = detailEvent.LinkId;
                this.HasMissingResources = detailEvent.HasMissingResources;
                this.EventStatusColor = detailEvent.EventStatusColor;
                this.RemindMinutesBefore = detailEvent.RemindMinutesBefore;
                this.HasReminder = detailEvent.HasReminder;
                this.IsPublishedToSognDK = detailEvent.IsPublishedToSognDK;
                this.EventStatusDescription = detailEvent.EventStatusDescription;
                this.EventStatusImageSource = detailEvent.EventStatusImageSource;
                this.EventMessage = detailEvent.EventMessage;
                this.IsReccuringEvent = detailEvent.IsReccuringEvent;
                this.HasLink = detailEvent.HasLink;
                this.IsProsteModulAppointment = detailEvent.IsProsteModulAppointment;
                this.HasEventMessage = detailEvent.HasEventMessage;
                this.PrimeLabel = detailEvent.PrimeLabel;
                this.IsIconListVisible = detailEvent.IsIconListVisible;
                this.EventStatusColorHex = detailEvent.EventStatusColorHex;
                this.TimeString = detailEvent.TimeString;
                this.DateString = detailEvent.DateString;
                this.SelectedResource = detailEvent.SelectedResource;
                this.StatStatus = detailEvent.StatStatus;
                this.IsXbridgeAppointment = detailEvent.IsXbridgeAppointment;
                this.EventPrimeLabelColorHex = detailEvent.EventPrimeLabelColorHex;
                this.ItemType = detailEvent.ItemType;
                this.TidImgSource = detailEvent.TidImgSource;
                this.TidColor = detailEvent.TidColor;
                this.EventTemplateID = detailEvent.EventTemplateID;
                this.LableListWidth = detailEvent.LableListWidth;
            }

            base.CopyFrom(other);
        }
    }

    public class SelectedLabelModel
    {
        public bool IsCancel { get; set; }
        public List<Guid> LabelIds { get; set; }

    }

    public class DetailPopUpEventModel : DetailEventModel
    {
        // public string UsersList { get; set; }
        public List<string> UsersList { get; set; } = new List<string>();
        // public string GroupsList { get; set; }
        public List<string> GroupsList { get; set; } = new List<string>();
        public string InternalComment { get; set; }
        public string FuneralDetails { get; set; }
        public bool IsInternalCommentVisible { get; set; }
        private bool _IsInternalCommentEnabled;
        public bool IsInternalCommentEnabled
        {
            get { return _IsInternalCommentEnabled; }
            set
            {
                _IsInternalCommentEnabled = value;
                OnPropertyChanged();
            }
        }
        private bool _IsFuneralSlotEnabled;
        public bool IsFuneralSlotEnabled
        {
            get { return _IsFuneralSlotEnabled; }
            set
            {
                _IsFuneralSlotEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsLabelsVisible
        {
            get
            {
                return EventLableList.Any();
            }
        }
        //public double LabelListHeight
        //{
        //    get
        //    {
        //        double ListHeight = 0;
        //        int Count = EventLableList.Count();
        //        if (Count == 0)
        //        {
        //            ListHeight = 0;
        //        }
        //        else if (Count < 4)
        //        {
        //            ListHeight = 22;
        //        }
        //        else if (Count < 7)
        //        {
        //            ListHeight = 44;
        //        }
        //        else
        //        {
        //            ListHeight = 66;
        //        }
        //        return ListHeight;
        //    }
        //}
        public CloseMode CloseMode { get; set; }
    }
}
