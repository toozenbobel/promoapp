﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace PromoApp.Converters
{
	public class BoolToStringConverter : IValueConverter
	{
		public string TrueString { get; set; }

		public string FalseString { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
