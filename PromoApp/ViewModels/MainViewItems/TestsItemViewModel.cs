using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Expression.Blend.SampleData.OfficesItemSampleData;
using PromoApp.DomainModel;
using PromoApp.Helpers;
using PromoApp.InterfaceModel;
using PromoApp.Models;
using PromoApp.ViewModels.Abstract;
using PromoApp.ViewModels.Entities;
using PromoApp.ViewModels.Pages;

namespace PromoApp.ViewModels.MainViewItems
{
	public class TestsItemViewModel : PanoramaItemViewModel
	{
		private readonly ITestsModel _model;
		private readonly CartModel _cart;
		private readonly INavigationService _navigationService;

		public override string Header
		{
			get { return "Анализы"; }
		}

		public TestsItemViewModel()
		{
			if (Execute.InDesignMode)
			{
				LoadDesignData();
			}
		}

		public TestsItemViewModel(ITestsModel model, CartModel cart, INavigationService navigationService)
		{
			_model = model;
			_cart = cart;
			_navigationService = navigationService;
		}

		protected override async void OnActivate()
		{
			base.OnActivate();

			_testModels = (await _model.GetTestsAsync()).ToList();

			FilterTests();
		}

		private void LoadDesignData()
		{
			var testModels = new List<Test>
			{
				new Test() {Id = 0, GroupId = 0, Name = "Общий анализ кровь", GroupName = "Кровь", Price = 100},
				new Test() {Id = 1, GroupId = 0, Name = "Лейкоцитарная формула", GroupName = "Кровь", Price = 500},
				new Test() {Id = 2, GroupId = 0, Name = "Анализ ВИЧ", GroupName = "Кровь", Price = 1000},
				new Test() {Id = 3, GroupId = 1, Name = "Общий анализ мочи", GroupName = "Моча", Price = 200},
				new Test() {Id = 4, GroupId = 1, Name = "Еще анализ", GroupName = "Моча", Price = 100},
				new Test() {Id = 5, GroupId = 1, Name = "И еще анализ", GroupName = "Моча", Price = 150},
				new Test() {Id = 6, GroupId = 2, Name = "Какой-то анализ", GroupName = "Анализ 1", Price = 100},
				new Test() {Id = 7, GroupId = 2, Name = "Еще один анализ", GroupName = "Анализ 1", Price = 750},
			};

			Tests = testModels
					.GroupBy(x => x.GroupName)
					.OrderBy(x => x.Key)
					.Select(x => new Grouping<string, TestViewModel>(x.Key, x.Select(i =>
					{
						var vm = new TestViewModel(null);
						vm.Model = i;
						return vm;
					}))).ToList();
		}

		private List<Test> _testModels = new List<Test>();

		private void FilterTests()
		{
			if (string.IsNullOrWhiteSpace(SearchString))
			{
				Tests = _testModels
					.GroupBy(x => x.GroupName)
					.OrderBy(x => x.Key)
					.Select(x => new Grouping<string, TestViewModel>(x.Key, x.Select(i =>
					{
						var vm = IoC.Get<TestViewModel>();
						vm.Model = i;
						return vm;
					}))).ToList();
			}
			else
			{
				Tests = _testModels
					.Where(x => x.GroupName.ToLower().Contains(SearchString.ToLower())
					|| x.Name.ToLower().Contains(SearchString.ToLower()))
					.GroupBy(x => x.GroupName)
					.OrderBy(x => x.Key)
					.Select(x => new Grouping<string, TestViewModel>(x.Key, x.Select(i =>
					{
						var vm = IoC.Get<TestViewModel>();
						vm.Model = i;
						return vm;
					}))).ToList();
			}
		}

		private List<Grouping<string, TestViewModel>> _tests;
		public List<Grouping<string, TestViewModel>> Tests
		{
			get { return _tests; }
			set
			{
				_tests = value;
				NotifyOfPropertyChange(() => Tests);
			}
		}

		private string _searchString;
		public string SearchString
		{
			get { return _searchString; }
			set
			{
				_searchString = value;
				NotifyOfPropertyChange(() => SearchString);

				FilterTests();
			}
		}

		public void AddItemsToCart()
		{
			foreach (var test in Tests.SelectMany(i => i))
			{
				if (test.IsChecked)
				{
					_cart.Put(test.Model);
					test.IsChecked = false;
				}
			}
		}

		public void GotoCart()
		{
			_navigationService.UriFor<CartViewModel>().Navigate();
		}
	}
}