using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Microsoft.Phone.Tasks;
using PromoApp.DomainModel;
using PromoApp.Implementation.SampleData;
using PromoApp.InterfaceModel;
using PromoApp.Services;

namespace PromoApp.ViewModels.Pages
{
	public class OfficePageViewModel : Screen
	{
		private readonly ICitiesService _citiesService;
		private readonly ILocationModel _locationModel;

		public OfficePageViewModel()
		{
			if (Execute.InDesignMode)
			{
				LoadDesignMode();
			}
		}

		private async void LoadDesignMode()
		{
			var citiesService = new CitiesService();
			Model = await citiesService.GetOfficeProfile(0);
		}

		public OfficePageViewModel(ICitiesService citiesService, ILocationModel locationModel)
		{
			_citiesService = citiesService;
			_locationModel = locationModel;
		}

		public int OfficeId { get; set; }

		protected override async void OnActivate()
		{
			base.OnActivate();

			Model = await _citiesService.GetOfficeProfile(OfficeId);
		}

		private FullOfficeModel _model;
		public FullOfficeModel Model
		{
			get { return _model; }
			set
			{
				_model = value;
				NotifyOfPropertyChange(() => Model);
				NotifyOfPropertyChange(() => OfficeLocation);
			}
		}

		public GeoCoordinate OfficeLocation
		{
			get
			{
				if (Model == null) 
					return null;

				return new GeoCoordinate(Model.Lat, Model.Lon);
			}
		}
	}
}
