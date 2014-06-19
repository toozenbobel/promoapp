using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;

namespace PromoApp.Models
{
	public class CartModel
	{
		private readonly List<Test> _inCart = new List<Test>();

		public List<Test> InCart
		{
			get
			{
				return _inCart;
			}
		}

		public void Put(Test toPlace)
		{
			if (InCart.All(x => x.Id != toPlace.Id))
			{
				InCart.Add(toPlace);
			}
		}

		public void ClearCart()
		{
			_inCart.Clear();
		}

		public event EventHandler ItemAdded;

		protected virtual void OnItemAdded()
		{
			EventHandler handler = ItemAdded;
			if (handler != null) handler(this, EventArgs.Empty);
		}
	}
}
