using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;

namespace PromoApp.Cache
{
	public class TestsCache
	{
		private List<Test> _items = new List<Test>();

		public void Set(IEnumerable<Test> items)
		{
			_items = items == null ? null : items.ToList();
		}

		public List<Test> Get()
		{
			return _items;
		}

		public Test ById(int id)
		{
			if (_items == null)
				return null;

			return _items.FirstOrDefault(i => i.Id == id);
		}
	}
}
