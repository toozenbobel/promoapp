using System.Windows;

namespace PromoApp.Controls
{
	public static class ExtensionMethods
	{
		public static Point GetRelativePosition(this UIElement element, UIElement other)
		{
			return element.TransformToVisual(other)
				.Transform(new Point(0, 0));
		}
	}
}