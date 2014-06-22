using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoApp.DomainModel;
using PromoApp.Services;

namespace PromoApp.Implementation.SampleData
{
	public class TestsService : ITestsService
	{
		public Task<IEnumerable<Test>> GetTests()
		{
			return Task.FromResult(new List<Test>
			{
				new Test() { Id = 0, GroupId = 0, Name = "Общий анализ кровь", GroupName = "Кровь", Price = 100, ReadyInDays = 1},
				new Test() { Id = 1, GroupId = 0, Name = "Лейкоцитарная формула", GroupName = "Кровь", Price = 500, ReadyInDays = 1},
				new Test() { Id = 2, GroupId = 0, Name = "Анализ ВИЧ", GroupName = "Кровь", Price = 1000, ReadyInDays = 1},
				new Test() { Id = 3, GroupId = 1, Name = "Общий анализ мочи", GroupName = "Моча", Price = 200, ReadyInDays = 1},
				new Test() { Id = 4, GroupId = 1, Name = "Еще анализ", GroupName = "Моча", Price = 100, ReadyInDays = 1},
				new Test() { Id = 5, GroupId = 1, Name = "И еще анализ", GroupName = "Моча", Price = 150, ReadyInDays = 1},
				new Test() { Id = 6, GroupId = 2, Name = "Какой-то анализ", GroupName = "Анализ 1", Price = 100, ReadyInDays = 1},
				new Test() { Id = 7, GroupId = 2, Name = "Еще один анализ", GroupName = "Анализ 1", Price = 750, ReadyInDays = 1},
			}.AsEnumerable());
		}
	}
}
