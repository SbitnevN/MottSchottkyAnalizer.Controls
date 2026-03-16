using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MottSchottkyAnalizer.Controls.Controls.LabeledTextBox;

public class LeftPaddingToMarginConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Thickness padding)
        {
            return new Thickness(padding.Left, 0, 0, 0);
        }

        return new Thickness(0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}