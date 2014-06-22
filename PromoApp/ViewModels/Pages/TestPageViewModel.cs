using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using PromoApp.Cache;
using PromoApp.DomainModel;
using PromoApp.Helpers;
using PromoApp.InterfaceModel;
using PromoApp.Models;
using PromoApp.Services;
using PromoApp.ViewModels.Entities;

namespace PromoApp.ViewModels.Pages
{
	public class TestPageViewModel : Screen
	{
		private readonly TestsCache _cache;
		private readonly CartModel _cart;
		private readonly IAddressListModel _addressList;

		public TestPageViewModel()
		{
			if (Execute.InDesignMode)
			{
				Model = new Test()
				{
					Name = "Общий анализ крови",
					Price = 500,
					ReadyInDays = 1,
					Remarks = new []
					{
						"Натощак"
					}
				};

				Offices = (new List<Office>
				{
					new Office {Id = 0, CityId = 2, Address = "Ново-Садовая 3", Lat = 53.205809, Lon = 50.127136},
					new Office {Id = 1, CityId = 2, Address = "Советской армии 133", Lat = 53.2156862, Lon = 50.2137857},
				}).Select(x =>
				{
					var vm = new OfficeViewModel(null);
					vm.Model = x;
					return vm;
				}).ToList();
			}
		}

		public TestPageViewModel(TestsCache cache, CartModel cart, IAddressListModel addressList)
		{
			_cache = cache;
			_cart = cart;
			_addressList = addressList;
		}

		public int TestId { get; set; }

		protected override async void OnActivate()
		{
			base.OnActivate();

			Model = _cache.ById(TestId);
			Offices = (await _addressList.GetOfficesForTests(new [] {0})).Select(x =>
			{
				var vm = IoC.Get<OfficeViewModel>();
				vm.Model = x;
				return vm;
			}).ToList();
		}

		private Test _model;
		public Test Model
		{
			get { return _model; }
			set
			{
				_model = value;
				NotifyOfPropertyChange(() => Model);
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

		public void AddToCart()
		{
			_cart.Put(Model);
		}
	}
}
