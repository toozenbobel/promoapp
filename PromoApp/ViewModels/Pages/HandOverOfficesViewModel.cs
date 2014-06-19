using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Expression.Blend.SampleData.OfficesItemSampleData;
using PromoApp.InterfaceModel;
using PromoApp.Models;
using PromoApp.ViewModels.Entities;

namespace PromoApp.ViewModels.Pages
{
	public class HandOverOfficesViewModel : Screen
	{
		private readonly IAddressListModel _model;
		private readonly ILocationModel _locationModel;
		private readonly CartModel _cart;

		public HandOverOfficesViewModel(IAddressListModel model, ILocationModel locationModel, CartModel cart)
		{
			_model = model;
			_locationModel = locationModel;
			_cart = cart;
		}

		public IEnumerable<int> Parameter { get; set; }

		protected override async void OnActivate()
		{
			base.OnActivate();

			if (_cart != null)
			{
				var offices = await _model.GetOfficesForTests(_cart.InCart.Select(x => x.Id));
				if (offices != null)
				{
					var location = await _locationModel.GetLastLocation();

					var vms = offices.Select(x =>
					{
						OfficeViewModel vm = new OfficeViewModel();
						vm.Model = x;
						vm.UserLocation = location;

						return vm;
					});

					Offices = vms.OrderBy(x => x.Distance).ThenBy(x => x.Model.Address).ToList();
				}
				else Offices = null;
			}
		}

		private List<OfficeViewModel> _offices;
		public List<OfficeViewModel> Offices
		{
			get { return _offices; }
			set
			{
				_offices = value;
				NotifyOfPropertyChange(() => Offices);
			}
		}
	}
}
