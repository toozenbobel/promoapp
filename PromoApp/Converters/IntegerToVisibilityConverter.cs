using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PromoApp.Converters
{
	public class IntegerToVisibilityConverter : IValueConverter
	{
		public bool Inverted { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int)
			{
				return ((int) value != 0 != Inverted) ? Visibility.Visible : Visibility.Collapsed;
			}

			return Inverted ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}