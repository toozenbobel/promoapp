using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace PromoApp.ViewModels.Abstract
{
	public abstract class PanoramaItemViewModel : Screen
	{
		public abstract string Header { get; }
	}
}
