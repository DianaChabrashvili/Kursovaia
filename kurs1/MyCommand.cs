using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

 namespace kurs1
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<Object> _action;

        public MyCommand(Action<Object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
                _action(parameter);
        }
    }
}
