using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using PromoApp.InterfaceModel;
using PromoApp.ViewModels.MainViewItems;

namespace PromoApp.ViewModels
{
	public class MainViewModel : Conductor<IScreen>.Collection.AllActive
	{
		private readonly OfficesItemViewModel _officesItem;
		private readonly TestsItemViewModel _testsItem;
		private readonly DiscountsItemViewModel _discountsItem;
		private readonly ILocationModel _locationModel;

		public MainViewModel(OfficesItemViewModel officesItem, TestsItemViewModel testsItem, DiscountsItemViewModel discountsItem,
			ILocationModel locationModel)
		{
			_officesItem = officesItem;
			_testsItem = testsItem;
			_discountsItem = discountsItem;
			_locationModel = locationModel;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			_locationModel.StartLocationServices();

			Items.Add(_officesItem);
			Items.Add(_testsItem);
			Items.Add(_discountsItem);

			ActivateItem(_officesItem);
		}
	}
}