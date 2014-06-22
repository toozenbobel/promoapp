using System;
using System.Collections.Generic;
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
	public class TestViewModel : PropertyChangedBase
	{
		private readonly INavigationService _navigationService;

		public TestViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		private bool _isChecked;
		public bool IsChecked
		{
			get { return _isChecked; }
			set
			{
				_isChecked = value;
				NotifyOfPropertyChange(() => IsChecked);
			}
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

		public ICommand TapCommand
		{
			get
			{
				return new RelayCommand(() => _navigationService.UriFor<TestPageViewModel>().WithParam(x => x.TestId, Model.Id).Navigate());
			}
		}
	}
}
