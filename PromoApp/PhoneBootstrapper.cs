using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Microsoft.Phone.Controls;
using PromoApp.Cache;
using PromoApp.Implementation.SampleData;
using PromoApp.InterfaceModel;
using PromoApp.Models;
using PromoApp.Services;
using PromoApp.ViewModels;
using PromoApp.ViewModels.Entities;
using PromoApp.ViewModels.MainViewItems;
using PromoApp.ViewModels.Pages;

namespace PromoApp
{
	public class Bootstrapper : PhoneBootstrapperBase
	{
		private PhoneContainer _container;

		public Bootstrapper()
		{
			Initialize();
		}

		protected override void Configure()
		{
			_container = new PhoneContainer();

			_container.RegisterPhoneServices(RootFrame);

			_container.PerRequest<MainViewModel>();
			_container.PerRequest<OfficesItemViewModel>();
			_container.PerRequest<DiscountsItemViewModel>();
			_container.PerRequest<TestsItemViewModel>();
			_container.PerRequest<TestViewModel>();
			_container.PerRequest<CartViewModel>();
			_container.PerRequest<HandOverOfficesViewModel>();
			_container.PerRequest<OfficeViewModel>();
			_container.PerRequest<OfficePageViewModel>();
			_container.PerRequest<TestPageViewModel>();

			_container.Singleton<CartModel>();
			_container.Singleton<TestsCache>();
			_container.Singleton<ITestsModel, TestsModel>();
			_container.Singleton<IAddressListModel, AddressListModel>();
			_container.Singleton<ILocationModel, LocationModel>();
			_container.Singleton<IDiscountsModel, DiscountsModel>();

			_container.PerRequest<ICitiesService, CitiesService>();
			_container.PerRequest<ITestsService, TestsService>();
			_container.PerRequest<IDiscountsService, DiscountsService>();
		}

		protected override Microsoft.Phone.Controls.PhoneApplicationFrame CreatePhoneApplicationFrame()
		{
			return new TransitionFrame();
		}

		protected override object GetInstance(Type service, string key)
		{
			return _container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}
	}
}

