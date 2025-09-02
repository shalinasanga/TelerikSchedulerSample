using Telerik.Maui.Controls.Compatibility;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TelerikMauiShellApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            NoUnderlineEntry();
            NoUnderlineDatePicker();
            NoUnderlineTimePicker();
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
        public static void NoUnderlineEntry()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                /*    Remove the underline from any IEntry visual elements on Android and IOS.  */
#if ANDROID
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
#if IOS
                h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                /*    Remove the underline from any IEditor visual elements on Android and IOS. */
#if ANDROID
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
#if IOS
                /*    Only reachable on iOS 15.0 or later.  */
#pragma warning disable CA1416 // Validate platform compatibility
                h.PlatformView.BorderStyle = UIKit.UITextViewBorderStyle.None;
#pragma warning restore CA1416 // Validate platform compatibility
#endif
            });
        }
        public static void NoUnderlineDatePicker()
        {
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                /*    Remove the underline from any IEntry visual elements on Android and IOS.  */
#if ANDROID
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
#if IOS
                h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
        public static void NoUnderlineTimePicker()
        {
            Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                /*    Remove the underline from any IEntry visual elements on Android and IOS.  */
#if ANDROID
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
#if IOS
                h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}
