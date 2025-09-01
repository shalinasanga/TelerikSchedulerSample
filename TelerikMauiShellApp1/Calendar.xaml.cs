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
        EventsCalendar.ScrollIntoView(new TimeOnly(UserProfileSettings.StartWorkingHours, 0, 0));
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
}