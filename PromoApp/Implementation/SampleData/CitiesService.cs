using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;
using PromoApp.Services;

namespace PromoApp.Implementation.SampleData
{
	public class CitiesService : ICitiesService
	{
		public Task<IEnumerable<City>> GetCities()
		{
			return Task.FromResult(new List<City>
			{
				new City() { Id = 0, Name = "Москва", Lat = 55.749792, Lon = 37.6324949, },
				new City() { Id = 1, Name = "Санкт-Петербург", Lat =59.9174455, Lon=30.3250575 },
				new City() { Id = 2, Name = "Самара", Lat=53.260908,Lon=50.198077 },
				new City() { Id = 3, Name = "Новокуйбышевск", Lat=53.0816435,Lon=49.910092 },
			}.AsEnumerable());
		}

		public Task<IEnumerable<Office>> GetOffices(int cityId)
		{
			return Task.FromResult(new List<Office>
			{
				new Office { Id = 0, CityId = 2, Address = "Ново-Садовая 3", Lat = 53.205809, Lon = 50.127136 },
				new Office { Id = 1, CityId = 2, Address = "Советской армии 133", Lat = 53.2156862, Lon = 50.2137857 },
				new Office { Id = 2, CityId = 2, Address = "Демократическая 13", Lat = 53.263438, Lon = 50.218702 },
			}.AsEnumerable());
		}

		public Task<IEnumerable<Office>> GetOffices(int cityId, IEnumerable<int> testsIds)
		{
			return Task.FromResult(new List<Office>
			{
				new Office { Id = 0, CityId = 2, Address = "Ново-Садовая 3", Lat = 53.205809, Lon = 50.127136 },
				new Office { Id = 1, CityId = 2, Address = "Советской армии 133", Lat = 53.2156862, Lon = 50.2137857 },
			}.AsEnumerable());
		}
	}
}
