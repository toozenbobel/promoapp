using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;

namespace PromoApp.Services
{
	public interface ITestsService
	{
		Task<IEnumerable<Test>> GetTests();
	}
}
