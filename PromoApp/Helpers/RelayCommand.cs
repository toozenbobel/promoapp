using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PromoApp.Helpers
{
	public class RelayCommand : RelayCommand<object>
	{
		public RelayCommand(Action execute)
			: base(_ => execute())
		{
		}

		public RelayCommand(Action execute, Predicate<object> canExecute)
			: base(_ => execute(), canExecute)
		{
		}
	}

	public class RelayCommand<TParam> : ICommand
	{
		#region Fields

		readonly Action<TParam> _execute;
		readonly Predicate<TParam> _canExecute;

		#endregion // Fields

		#region Constructors

		public RelayCommand(Action<TParam> execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action<TParam> execute, Predicate<TParam> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		#region ICommand Members

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute((TParam)parameter);
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			_execute((TParam)parameter);
		}

		#endregion // ICommand Members
	}
}
