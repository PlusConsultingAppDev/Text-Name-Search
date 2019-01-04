using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PlusConsulting.NameSearch.WpfApp.Converters
{
    public class TextToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (!(value is string text))
                return null;

            return string.IsNullOrEmpty(text)
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
