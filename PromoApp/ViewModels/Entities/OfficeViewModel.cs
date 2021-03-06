﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using PromoApp.DomainModel;
using PromoApp.Helpers;
using PromoApp.ViewModels.Pages;

namespace PromoApp.ViewModels.Entities
{
	public class OfficeViewModel : PropertyChangedBase
	{
		private readonly INavigationService _navigationService;

		public OfficeViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		private Office _model;
		public Office Model
		{
			get { return _model; }
			set
			{
				_model = value;
				NotifyOfPropertyChange(() => Model);

				Recalculate();
			}
		}

		private GeoCoordinate _userLocation;
		public GeoCoordinate UserLocation
		{
			get { return _userLocation; }
			set
			{
				_userLocation = value;
				NotifyOfPropertyChange(() => UserLocation);

				Recalculate();
			}
		}

		private double _distance;
		public double Distance
		{
			get { return _distance; }
			set
			{
				_distance = value;
				NotifyOfPropertyChange(() => Distance);
				NotifyOfPropertyChange(() => DistanceString);
			}
		}

		public string DistanceString
		{
			get { return string.Format("{0:0.0} км", Distance / 1000.0); }
		}

		private void Recalculate()
		{
			if (UserLocation != null && Model != null)
			{
				GeoCoordinate modelLocation = new GeoCoordinate(Model.Lat, Model.Lon);
				Distance = UserLocation.GetDistanceTo(modelLocation);
			}
			else Distance = 0;
		}

		public ICommand TapCommand
		{
			get
			{
				return new RelayCommand(() => _navigationService.UriFor<OfficePageViewModel>().WithParam(x => x.OfficeId, Model.Id).Navigate());
			}
		}
	}
}
