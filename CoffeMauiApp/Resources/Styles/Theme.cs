using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMauiApp.Resources.Styles;

public class Theme
{
    public static Color Bg = Color.FromArgb("#0C0F14");
    public static Color Cam = Color.FromArgb("#D17842");
    public static Color BorderColor = Color.FromArgb("#22272F");
    public static Color BorderBg = Color.FromArgb("#141921");
    public static Color Search = Color.FromArgb("#52555A");
    public static Brush BgItem = new LinearGradientBrush(
                                    new GradientStopCollection
                                    {
                                        new GradientStop(Color.FromArgb("#26282E"), 0.1535f),
                                        new GradientStop(Color.FromArgb("#0C0F14"), 0.8795f),
                                    });


}
