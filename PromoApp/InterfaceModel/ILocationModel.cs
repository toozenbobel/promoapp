using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoApp.InterfaceModel
{
	public interface ILocationModel
	{
		event EventHandler StateChanged;
		bool IsLocationBusy { get; }
		bool IsLocationReady { get; }
		bool IsFailed { get; }
		void StartLocationServices();
		void StopLocationServices();
		Task<GeoCoordinate> GetLastLocation();
	}
}
