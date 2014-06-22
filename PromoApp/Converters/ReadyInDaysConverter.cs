using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PromoApp.Converters
{
	public  class ReadyInDaysConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int)
			{
				int iValue = (int) value;
				if (iValue == 1)
					return "На следующий день";
				return string.Format("Через {0} дней", iValue);
			}
			return "нет данных";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
