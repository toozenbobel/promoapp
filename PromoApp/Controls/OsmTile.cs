using System;
using Microsoft.Phone.Maps.Controls;

namespace PromoApp.Controls
{
	public class OsmTile : TileSource
	{
		public OsmTile()
		{
			UriFormat = "http://static.tiles.who-where.ru/mapnik/{0}/{1}/{2}.png";
		}

		public override Uri GetUri(int x, int y, int zoomLevel)
		{
			if (zoomLevel > 0)
			{
				var url = string.Format(UriFormat, zoomLevel, x, y);
				return new Uri(url);
			}
			return null;
		}
	}
}
