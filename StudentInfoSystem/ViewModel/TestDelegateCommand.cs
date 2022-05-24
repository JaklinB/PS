using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModel
{
    internal class TestDelegateCommand : ICommand

    {
        private readonly Action _action;
        public TestDelegateCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
