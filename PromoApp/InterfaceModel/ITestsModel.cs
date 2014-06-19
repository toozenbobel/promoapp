using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;

namespace PromoApp.InterfaceModel
{
	public interface ITestsModel
	{
		Task<IEnumerable<Test>> GetTestsAsync();
	}
}
