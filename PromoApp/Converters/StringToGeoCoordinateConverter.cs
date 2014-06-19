using System;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace PromoApp.Converters
{
	public class StringToGeoCoordinateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;

			string strValue = value.ToString();

			var coords = strValue.Split(',').Select(s => Double.Parse(s, CultureInfo.InvariantCulture)).ToArray();

			GeoCoordinate coordinates = new GeoCoordinate();
			coordinates.Latitude = coords[0];
			coordinates.Longitude = coords[1];

			return coordinates;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
