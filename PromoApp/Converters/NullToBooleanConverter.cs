using System;
using System.Globalization;
using System.Windows.Data;

namespace PromoApp.Converters
{
    public class NullToBooleanConverter : IValueConverter
    {
		public bool Inverted { get; set; }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
	        var convert = DirectConvert(value);
	        return Inverted ? !convert : convert;
        }

	    private static bool DirectConvert(object value)
	    {
		    var stringValue = value as string;
		    if (stringValue != null)
		    {
			    return !String.IsNullOrWhiteSpace(stringValue);
		    }

		    return value != null;
	    }

	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}