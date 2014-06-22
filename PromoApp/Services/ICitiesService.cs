using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;

namespace PromoApp.Services
{
	public interface ICitiesService
	{
		Task<IEnumerable<City>> GetCities();
		Task<IEnumerable<Office>> GetOffices(int cityId);
		Task<IEnumerable<Office>> GetOffices(int cityId, IEnumerable<int> testsIds);
		Task<FullOfficeModel> GetOfficeProfile(int id);
	}

}
