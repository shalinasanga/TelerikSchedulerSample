using Telerik.Maui;

namespace TelerikMauiShellApp1;

public partial class Calendar : ContentPage
{
	public Calendar()
	{
        TelerikLocalizationManager.Manager.ResourceManager = AppResources.ResourceManager;
        InitializeComponent();
        BindingContext = new CalendarViewModel();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as CalendarViewModel;
        EventsCalendar.ScrollIntoView(new TimeOnly(UserProfileSettings.StartWorkingHours, 0, 0));
        if (EventsCalendar.IsLoaded)
        {
            _ = vm.GetEvents();
        }
    }
    private void EventsCalendar_Loaded(object sender, EventArgs e)
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {

                _ = (BindingContext as CalendarViewModel).GetEvents();
            });
        }
        catch (Exception ex)
        {
           DisplayAlert("Error", ex.Message, "OK");
        }
    }
 private async void AgendaSelectSegment_Clicked(object sender, EventArgs e)
    {
       
    }
    private void EventsCalendar_AppointmentTapped(object sender, Telerik.Maui.Controls.Scheduler.TappedEventArgs<Telerik.Maui.Controls.Scheduler.Occurrence> e)
    {

    }

    private void EventsCalendar_SlotTapped(object sender, Telerik.Maui.Controls.Scheduler.TappedEventArgs<Telerik.Maui.Controls.Scheduler.Slot> e)
    {

    }

    private void EventsCalendar_MonthDayTapped(object sender, Telerik.Maui.Controls.Scheduler.TappedEventArgs<DateTime> e)
    {

    }

    private void EventsCalendar_DialogOpening(object sender, Telerik.Maui.Controls.Scheduler.SchedulerDialogOpeningEventArgs e)
    {

    }

    private void FilterImg_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void SearchFrame_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void NewApppointment_Tapped(object sender, TappedEventArgs e)
    {

    }
}