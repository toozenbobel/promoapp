using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Expression.Blend.SampleData.OfficesItemSampleData;
using PromoApp.DomainModel;
using PromoApp.Models;
using PromoApp.ViewModels.Entities;

namespace PromoApp.ViewModels.Pages
{
	public class CartViewModel : Screen
	{
		public CartViewModel()
		{
			if (Execute.InDesignMode)
			{
				var models = new List<Test>
				{
					new Test() {Id = 0, GroupId = 0, Name = "Общий анализ кровь", GroupName = "Кровь", Price = 100},
					new Test() {Id = 1, GroupId = 0, Name = "Лейкоцитарная формула", GroupName = "Кровь", Price = 500},
					new Test() {Id = 2, GroupId = 0, Name = "Анализ ВИЧ", GroupName = "Кровь", Price = 1000},
				};

				TestsInCart = models.Select(x =>
				{
					TestViewModel vm = new TestViewModel(null);
					vm.Model = x;
					return vm;
				}).ToList();
			}
		}

		private readonly CartModel _model;
		private readonly INavigationService _navigationService;

		public CartViewModel(CartModel model, INavigationService navigationService)
		{
			_model = model;
			_navigationService = navigationService;
		}

		protected override void OnActivate()
		{
			base.OnActivate();

			TestsInCart = _model.InCart.Select(x =>
			{
				TestViewModel vm = IoC.Get<TestViewModel>();
				vm.Model = x;
				return vm;
			}).ToList();
		}

		private List<TestViewModel> _testsInCart;
		public List<TestViewModel> TestsInCart
		{
			get { return _testsInCart; }
			set
			{
				_testsInCart = value;
				NotifyOfPropertyChange(() => TestsInCart);
				NotifyOfPropertyChange(() => TotalPrice);
			}
		}

		public int TotalPrice
		{
			get
			{
				if (TestsInCart != null)
				{
					return TestsInCart.Sum(x => x.Model.Price);
				}

				return 0;
			}
		}

		public void HandOver()
		{
			_navigationService.UriFor<HandOverOfficesViewModel>().WithParam(p => p.Parameter, TestsInCart.Select(x => x.Model.Id)).Navigate();
		}
	}
}
