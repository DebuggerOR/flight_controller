using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSimulator.Models;
using FlightSimulator.Models.Interface;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels.Windows
{
    public class SettingsWindowViewModel : BaseNotify
    {
        private ISettingsModel model;
        
        public SettingsWindowViewModel()
        {
            this.model = new ApplicationSettingsModel();
        }

        public Action CloseAction {get; set;}

        public string FlightServerIP
        {
            get
            {
                return this.model.FlightServerIP;
            }
            set
            {
                this.model.FlightServerIP = value;
                this.NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int FlightCommandPort
        {
            get
            {
                return this.model.FlightCommandPort;
            }
            set
            {
                this.model.FlightCommandPort = value;
                this.NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get
            {
                return this.model.FlightInfoPort;
            }
            set
            {
                this.model.FlightInfoPort = value;
                this.NotifyPropertyChanged("FlightInfoPort");
            }
        }

        public void SaveSettings()
        {
            this.model.SaveSettings();
        }

        public void ReloadSettings()
        {
            this.model.ReloadSettings();
            FlightServerIP = this.model.FlightServerIP;
            FlightInfoPort = this.model.FlightInfoPort;
            FlightCommandPort = this.model.FlightCommandPort;
        }

        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand 
                    = new CommandHandler(() => OkOnClick()));
            }
        }

        private void OkOnClick()
        {
            this.SaveSettings();
            this.CloseAction();        
        }


        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand 
                    = new CommandHandler(() => CancelOnClick()));
            }
        }

        private void CancelOnClick()
        {
            this.ReloadSettings();
            this.CloseAction();        
        }
    }
}

