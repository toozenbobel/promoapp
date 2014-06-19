using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using PromoApp.DomainModel;
using PromoApp.Services;

namespace PromoApp.Implementation.SampleData
{
	public class DiscountsService : IDiscountsService
	{
		public Task<IEnumerable<Discount>> GetDiscounts()
		{
			return Task.FromResult(new List<Discount>
			{
				new Discount() { Id = 0, Content="Скидка 20% на все анализы в филиале на Демократической"},
				new Discount() { Id = 1, Content="Скидка 50% на детские анализы во всех филиалах до 24 апреля"},
				new Discount() { Id = 2, Content="Общий анализ крови по цене какого-то другого анализа"},
			}.AsEnumerable());
		}
	}
}
