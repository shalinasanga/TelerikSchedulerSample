using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace TelerikMauiShellApp1
{
    public class ArgbToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value;

            if (color == null)
            {
                return Colors.LightGray;
            }
            else
            {
                color = Color.FromArgb(color.ToString());
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Colors.White;
        }
    }

    public class EventStatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string iconName = String.Empty;
            if (value != null)
            {
                if ((string)value != String.Empty)
                {

                    if ((string)value == "#FF00B050")
                    {
                        iconName = "";
                    }
                    else if ((string)value == "#FFFFFF00")
                    {
                        iconName = "ic_event_status_planning_yellow.png";
                    }
                    else
                    {
                        iconName = "ic_event_status_temp_red.png";
                    }
                }
                else
                {
                    iconName = String.Empty;
                }

            }

            return iconName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Empty;
        }
    }

    public class StatStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = Colors.Transparent;
            var StatStatus = (StatStatusEnum)value;

            switch (StatStatus)
            {
                case StatStatusEnum.NoCodesAdded:
                    color = Colors.Red;
                    break;
                case StatStatusEnum.NoValuesAdded:
                    color = Colors.Yellow;
                    break;
                case StatStatusEnum.Ok:
                    color = Colors.Green;
                    break;
                default:
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Colors.White;
        }
    }

    public class StatStatusToEnableColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color isEnabledColor = Color.FromArgb("#00A99D");
            var StatStatus = (StatStatusEnum)value;

            if (StatStatus == StatStatusEnum.NoCodesAdded)
            {
                isEnabledColor = Color.FromArgb("#d3d3d3");
            }

            return isEnabledColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }

    public class AlternativeRowColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color rowcolor = Colors.White;
            if (((int)value) % 2 == 0)//even
            {
                rowcolor = Color.FromArgb("#E0E0E0");
            }
            else//odd
            {

                rowcolor = Colors.White;
            }

            return rowcolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }

    public class StatEnabledToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color isEnabledColor = Color.FromArgb("#00A99D");
            var Status = (bool)value;

            if (!Status)
            {
                isEnabledColor = Color.FromArgb("#dddddd");
            }

            return isEnabledColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }

    public class StatEnabledToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color textcolor = Color.FromArgb("#2F4F4F");
            var Status = (bool)value;

            if (!Status)
            {
                textcolor = Color.FromArgb("#dddddd");
            }

            return textcolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromArgb("#2F4F4F");
        }
    }
    public class LabelColorToTintConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                DetailEventModel appointment = (DetailEventModel)value;
                if (appointment == null)
                {
                    return Color.FromArgb("#F5F5F5");
                }
                else if (appointment.EventLableList.Any())
                {
                    return Color.FromArgb(appointment.EventLableList[0].HexColor).MultiplyAlpha(0.20f);
                    // return ColorChanger.ChangeColorBrightness(ColorTranslator.FromHtml(appointment.EventLableList[0].HexColor), 0.85f);
                    // return (ColorConverters.FromHex(appointment.EventLableList[0].HexColor)).GetComplementary();
                }
                else
                {
                    return Colors.Red;
                }
            }
            catch (Exception ex)
            {
                return Color.FromArgb("#F5F5F5");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromArgb("#2F4F4F");
        }
    }
    public class LabelColorToTintDefaultWhiteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DetailEventModel appointment = (DetailEventModel)value;
            if (appointment.EventLableList.Any())
            {
                return ColorChanger.ChangeColorBrightness(ColorTranslator.FromHtml(appointment.EventLableList[0].HexColor), 0.85f);
                // return (ColorConverters.FromHex(appointment.EventLableList[0].HexColor)).GetComplementary();
            }
            else
            {
                return Colors.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Colors.White;
        }
    }
    public class LabelColorToTintDefaultWhiteForHomeViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DynamicEventModel appointment = (DynamicEventModel)value;
            if (appointment == null)
            {
                return Colors.White;
            }
            else if (appointment.EventLableList.Any())
            {
                // return Color.FromArgb(ColorChanger.ChangeColorBrightness(ColorTranslator.FromHtml(appointment.EventLableList[0].HexColor), 0.85f).ToArgb().ToString());
                // return (ColorConverters.FromHex(appointment.EventLableList[0].HexColor)).GetComplementary();
                return Color.FromArgb(appointment.EventLableList[0].HexColor).MultiplyAlpha(0.20f);
            }
            else
            {
                return Colors.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Colors.White;
        }
    }
    public class StatCodeEnableToBackgroudnColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Colors.White;

            }
            else
            {
                return Colors.LightGray;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Colors.White;
        }
    }
}
