using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;

namespace PromoApp.InterfaceModel
{
	public interface IAddressListModel
	{
		Task<IEnumerable<City>> GetCitiesAsync();
		void SelectCity(long id);
		Task<IEnumerable<Office>>  GetOfficesAsync();
		Task<IEnumerable<Office>> GetOfficesForTests(IEnumerable<int> testsIds);
		Task<FullOfficeModel> GetOfficeProfile(int id);
	}
}
