using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.InterfaceModel;

namespace PromoApp.Models
{
	public class LocationModel : ILocationModel
	{
		public LocationModel()
		{
			GeoWatcher.PositionChanged += OnLocation;
		}

		private static readonly GeoCoordinateWatcher GeoWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);

		public void StartLocationServices()
		{
			if (GeoWatcher.Permission == GeoPositionPermission.Granted && GeoWatcher.Status != GeoPositionStatus.Ready)
			{
				IsLocationBusy = true;
				GeoWatcher.Start();
			}
		}

		public void StopLocationServices()
		{
			IsLocationBusy = false;
			IsFailed = false;
			IsLocationReady = false;

			GeoWatcher.Stop();
		}

		readonly TaskCompletionSource<GeoCoordinate> _taskFactory = new TaskCompletionSource<GeoCoordinate>();

		public async Task<GeoCoordinate> GetLastLocation()
		{
			if (IsLocationBusy)
			{
				if (await Task.WhenAny(_taskFactory.Task, Task.Delay(5000)) == _taskFactory.Task)
				{
					return _taskFactory.Task.Result;
				}
				else
				{
					return null;
				}
			}
			
			if (IsLocationReady)
				return GeoWatcher.Position.Location;

			return null;
		}

		private void OnLocation(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
		{
			IsLocationBusy = false;
			IsFailed = false;
			IsLocationReady = true;

			_taskFactory.TrySetResult(e.Position.Location);

			OnStateChanged();
		}

		public event EventHandler StateChanged;
		protected virtual void OnStateChanged()
		{
			EventHandler handler = StateChanged;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		public bool IsLocationBusy { get; private set; }
		public bool IsLocationReady { get; private set; }
		public bool IsFailed { get; private set; }
	}
}
