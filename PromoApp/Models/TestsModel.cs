using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.Cache;
using PromoApp.DomainModel;
using PromoApp.InterfaceModel;
using PromoApp.Services;

namespace PromoApp.Models
{
	public class TestsModel : ITestsModel
	{
		private readonly ITestsService _testsService;
		private readonly TestsCache _cache;

		public TestsModel(ITestsService testsService, TestsCache cache)
		{
			_testsService = testsService;
			_cache = cache;
		}

		public async Task<IEnumerable<Test>> GetTestsAsync()
		{
			var tests = await _testsService.GetTests();
			if (tests != null)
			{
				_cache.Set(tests);
				return tests;
			}

			return null;
		}
	}
}
