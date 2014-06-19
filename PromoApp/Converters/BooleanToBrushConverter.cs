using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PromoApp.Converters
{
	public class BooleanToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{
				return (bool) value ? TrueBrush : FalseBrush;
			}

			return FalseBrush;
		}

		public Brush FalseBrush { get; set; }

		public Brush TrueBrush { get; set; }


		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}