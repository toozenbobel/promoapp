using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;
using PromoApp.InterfaceModel;
using PromoApp.Services;

namespace PromoApp.Models
{
	public class TestsModel : ITestsModel
	{
		private readonly ITestsService _testsService;

		public TestsModel(ITestsService testsService)
		{
			_testsService = testsService;
		}

		public async Task<IEnumerable<Test>> GetTestsAsync()
		{
			var tests = await _testsService.GetTests();
			if (tests != null)
			{
				return tests;
			}

			return null;
		}
	}
}
