using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PromoApp.Controls
{
	public partial class TapContainer : ContentControl
	{
		public TapContainer()
		{
			InitializeComponent();
		}

		public object TapParameter
		{
			get
			{
				return GetValue(TapParameterProperty);
			}
			set
			{
				SetValue(TapParameterProperty, value);
			}
		}

		public static readonly DependencyProperty TapParameterProperty = DependencyProperty.Register("TapParameter",
																									 typeof(object),
																									 typeof(TapContainer),
																									 new PropertyMetadata(null));

		public ICommand TapCommand
		{
			get
			{
				return (ICommand)GetValue(TapCommandProperty);
			}
			set
			{
				SetValue(TapCommandProperty, value);
			}
		}

		// Using a DependencyProperty as the backing store for TapCommand.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TapCommandProperty =
			DependencyProperty.Register("TapCommand", typeof(ICommand), typeof(TapContainer), new PropertyMetadata(null));

		private void TapContainer_OnTap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			if (TapCommand != null)
				TapCommand.Execute(TapParameter);
		}
	}
}
