using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using PromoApp.DomainModel;
using PromoApp.Implementation.SampleData;
using PromoApp.InterfaceModel;
using PromoApp.ViewModels.Abstract;

namespace PromoApp.ViewModels.MainViewItems
{
	public class DiscountsItemViewModel : PanoramaItemViewModel
	{
		private readonly IDiscountsModel _model;

		public override string Header
		{
			get { return "Скидки"; }
		}

		public DiscountsItemViewModel()
		{
			if (Execute.InDesignMode)
			{
				LoadDesignData();
				
			}
		}

		private async void LoadDesignData()
		{
			var service = new DiscountsService();
			Discounts = (await service.GetDiscounts()).ToList();
		}

		public DiscountsItemViewModel(IDiscountsModel model)
		{
			_model = model;
		}

		protected override async void OnActivate()
		{
			base.OnActivate();

			Discounts = (await _model.GetDiscountsAsync()).ToList();
		}

		private List<Discount> _discounts;
		public List<Discount> Discounts
		{
			get { return _discounts; }
			set
			{
				_discounts = value;
				NotifyOfPropertyChange(() => Discounts);
			}
		}
	}
}