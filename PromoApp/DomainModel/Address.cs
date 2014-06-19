using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoApp.DomainModel
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Lon { get; set; }
		public double Lat { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

	public class Address
	{
	}
}
