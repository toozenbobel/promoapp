using System.Collections.Generic;

namespace PromoApp.Controls
{
	/// <summary>
	/// Defines an interface that must be implemented to generate the LinqToTree methods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ILinqTree<T>
	{
		IEnumerable<T> Children();

		T Parent { get; }
	}
}