using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFMVVMApplication.CM
{
    class MaskCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;

        public MaskCommand(Action<object> a, Func<object, bool> f)
        {
            executeAction = a;
            canExecute = f;
        }


        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }
        }

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
            
    }
}
