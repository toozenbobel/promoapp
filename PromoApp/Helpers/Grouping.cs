using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoApp.Helpers
{
	public class Grouping<TKey, TElement> : List<TElement>
	{
		private readonly TKey _key;

		public Grouping(TKey key, IEnumerable<TElement> items)
			: base(items)
		{
			_key = key;
		}

		public TKey Key
		{
			get { return _key; }
		}
	}
}
