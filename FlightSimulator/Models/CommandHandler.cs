using System;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FlightSimulator.Models
{
    public class CommandHandler : ICommand
    {
        private Action action;
        public CommandHandler(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
