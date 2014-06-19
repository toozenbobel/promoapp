using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;
using PromoApp.InterfaceModel;
using PromoApp.Services;
using PromoApp.ViewModels.Abstract;
using PromoApp.ViewModels.Entities;

namespace PromoApp.ViewModels.MainViewItems
{
	public class OfficesItemViewModel : PanoramaItemViewModel
	{
		private readonly IAddressListModel _model;
		private readonly ILocationModel _locationModel;

		public OfficesItemViewModel(IAddressListModel model, ILocationModel locationModel)
		{
			_model = model;
			_locationModel = locationModel;
		}

		public override string Header
		{
			get { return "Адреса"; }
		}

		protected override async void OnActivate()
		{
			base.OnActivate();

			var fromModel = await _model.GetCitiesAsync();
			if (fromModel != null)
			{
				Cities = fromModel.ToList();
				SelectedCity = Cities.FirstOrDefault();
			}
			else
			{
				Cities = null;
				SelectedCity = null;
			}
		}

		private City _selectedCity;
		public City SelectedCity
		{
			get { return _selectedCity; }
			set
			{
				_selectedCity = value;
				NotifyOfPropertyChange(() => SelectedCity);

				if (SelectedCity != null)
				{
					_model.SelectCity(SelectedCity.Id);
					LoadOffices();
				}
			}
		}

		private async void LoadOffices()
		{
			var offices = await _model.GetOfficesAsync();

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

		private List<City> _cities;
		public List<City> Cities
		{
			get { return _cities; }
			set
			{
				_cities = value;
				NotifyOfPropertyChange(() => Cities);
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
