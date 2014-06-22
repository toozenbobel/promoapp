using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoApp.DomainModel
{
	public class Service
	{
		public string Name { get; set; }
	}

	public class FullOfficeModel
	{
		public int Id { get; set; }
		public int CityId { get; set; }
		public string Address { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		public string Description { get; set; }
		public string Phone { get; set; }
		public IEnumerable<Service> Services { get; set; } 
	}
}
