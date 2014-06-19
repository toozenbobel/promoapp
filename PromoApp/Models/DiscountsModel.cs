using System.Collections.Generic;
using System.Threading.Tasks;
using PromoApp.DomainModel;
using PromoApp.InterfaceModel;
using PromoApp.Services;

namespace PromoApp.Models
{
	public class DiscountsModel : IDiscountsModel
	{
		private readonly IDiscountsService _discountsService;

		public DiscountsModel(IDiscountsService discountsService)
		{
			_discountsService = discountsService;
		}

		public async Task<IEnumerable<Discount>> GetDiscountsAsync()
		{
			var discounts = await _discountsService.GetDiscounts();
			if (discounts != null)
			{
				return discounts;
			}

			return null;
		}
	}
}