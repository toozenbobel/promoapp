using System;
using System.Windows;
using System.Windows.Data;

namespace PromoApp.Converters
{
    public class CountToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int count = (int)value;

            Visibility returnValue = count > 0 ? Visibility.Visible : Visibility.Collapsed;

            if (Inverted)
            {
                returnValue = returnValue == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }

            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
