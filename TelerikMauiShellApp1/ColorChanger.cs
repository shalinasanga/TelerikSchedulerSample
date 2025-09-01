using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace TelerikMauiShellApp1
{
    public static class ColorChanger
    {
        public static Color InterpolateColors(Color color1, Color color2, float percentage)
        {
            double a1 = color1.A / 255.0, r1 = color1.R / 255.0, g1 = color1.G / 255.0, b1 = color1.B / 255.0;
            double a2 = color2.A / 255.0, r2 = color2.R / 255.0, g2 = color2.G / 255.0, b2 = color2.B / 255.0;

            byte a3 = Convert.ToByte((a1 + (a2 - a1) * percentage) * 255);
            byte r3 = Convert.ToByte((r1 + (r2 - r1) * percentage) * 255);
            byte g3 = Convert.ToByte((g1 + (g2 - g1) * percentage) * 255);
            byte b3 = Convert.ToByte((b1 + (b2 - b1) * percentage) * 255);
            return Color.FromArgb(a3, r3, g3, b3);
        }
        /// <summary>
        /// Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
        /// Negative values produce darker colors.</param>
        /// <returns>
        /// Corrected <see cref="Color"/> structure.
        /// </returns>
        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            try
            {
                float red = (float)color.R;
                float green = (float)color.G;
                float blue = (float)color.B;

                if (correctionFactor < 0)
                {
                    correctionFactor = 1 + correctionFactor;
                    red *= correctionFactor;
                    green *= correctionFactor;
                    blue *= correctionFactor;
                }
                else
                {
                    red = (255 - red) * correctionFactor + red;
                    green = (255 - green) * correctionFactor + green;
                    blue = (255 - blue) * correctionFactor + blue;
                }

                return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
            }
            catch (Exception ex)
            {
                return color;
            }
        }
    }
}
