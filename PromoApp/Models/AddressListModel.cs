using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;
using PromoApp.InterfaceModel;
using PromoApp.Services;

namespace PromoApp.Models
{
	public class AddressListModel : IAddressListModel
	{
		private readonly ICitiesService _citiesService;
		private readonly ILocationModel _locationModel;

		public AddressListModel(ICitiesService citiesService, ILocationModel locationModel)
		{
			_citiesService = citiesService;
			_locationModel = locationModel;
		}

		private List<City> _cities;

		public City SelectedCity { get; private set; }

		public async Task<IEnumerable<City>> GetCitiesAsync()
		{
			if (_cities == null)
			{
				var cities = await _citiesService.GetCities();
				if (cities != null)
				{
					var location = await _locationModel.GetLastLocation();
					if (location != null)
					{
						var loadedCities = cities.ToList();
						var firstItem = loadedCities.First(
							c => Math.Abs(location.GetDistanceTo(new GeoCoordinate(c.Lat, c.Lon)) -
							              loadedCities.Min(lc => location.GetDistanceTo(new GeoCoordinate(lc.Lat, lc.Lon)))) < 0.0001);

						List<City> newFormedList = new List<City>();
						newFormedList.Add(firstItem);
						newFormedList.AddRange(loadedCities.Where(lc => lc.Id != firstItem.Id));

						_cities = newFormedList;
					}
					else
					{
						_cities = cities.ToList();
					}
				}
			}

			return _cities;
		}

		public void SelectCity(long id)
		{
			SelectedCity = _cities != null ? _cities.FirstOrDefault(c => c.Id == id) : null;
		}

		public async Task<IEnumerable<Office>> GetOfficesAsync()
		{
			if (SelectedCity != null)
			{
				return await _citiesService.GetOffices(SelectedCity.Id);
			}
			
			return null;
		}

		public async Task<IEnumerable<Office>> GetOfficesForTests(IEnumerable<int> testsIds)
		{
			if (SelectedCity != null)
			{
				return await _citiesService.GetOffices(SelectedCity.Id, testsIds);
			}

			return null;
		}
	}
}
