using Telerik.Maui.Controls.Compatibility;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TelerikMauiShellApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseTelerik()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Helvetica.ttf", "HelveticaRegular");
                    fonts.AddFont("Helvetica-Bold.ttf", "HelveticaBold");
                    fonts.AddFont("Helvetica-light.ttf", "HelveticaLight");
                });

            return builder.Build();
        }
    }
}
