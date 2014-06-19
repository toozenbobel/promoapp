using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoApp.DomainModel
{
	public class Office
	{
		public int Id { get; set; }
		public int CityId { get; set; }
		public string Address { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
	}
}
