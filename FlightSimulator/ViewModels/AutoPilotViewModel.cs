using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using FlightSimulator.Models;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : INotifyPropertyChanged
    {
        private AutoPilotModel model;
        private Brush background;
        private string commands;

        public AutoPilotViewModel()
        {
            this.model = new AutoPilotModel();
            this.background = Brushes.LightPink;

            // 2 commands that written as default
            this.commands = "set controls/flight/rudder -1\r\nset controls/flight/rudder 1\r\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Commands
        {
            get
            {
                return this.commands;
            }
            set
            {
                this.commands = value;
                if (!string.IsNullOrEmpty(Commands) && this.Background == Brushes.White)
				{
					this.Background = Brushes.LightPink;
				}
                else if (string.IsNullOrEmpty(Commands))
				{
					this.Background = Brushes.White;
				}
            }
        }
		
        public Brush Background
        {
            get
            {
                return this.background;
            }
            set
            {
                this.background = value;
                this.NotifyPropertyChanged("Background");
            }
        }

        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() => OkOnClick()));
            }
        }

        public void OkOnClick()
        {
            this.model.SendCommands(Commands, this);
			this.Commands = "";
            this.NotifyPropertyChanged(Commands);
            this.Background = Brushes.White; 
        }


        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() => ClearOnClick()));
            }
        }

        public void ClearOnClick()
        {
            this.Commands = "";
            this.Background = Brushes.White;
            this.NotifyPropertyChanged(Commands);
        }
    }
}
