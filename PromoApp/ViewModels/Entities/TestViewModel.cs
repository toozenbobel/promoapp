using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using PromoApp.DomainModel;

namespace PromoApp.ViewModels.Entities
{
	public class TestViewModel : PropertyChangedBase
	{
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
	}
}
