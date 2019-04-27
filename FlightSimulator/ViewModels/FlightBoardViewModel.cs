using System;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;
using FlightSimulator.Models;
using FlightSimulator.Communication;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private bool isConnected;
        private Settings settings;
        private FlightBoardModel model;

        public FlightBoardViewModel()
        {
            this.isConnected = false;
            this.model = new FlightBoardModel();
            this.model.PropertyChanged += M_PropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void M_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lat"))
            {
                this.NotifyPropertyChanged("Lat");
            }
            else if (e.PropertyName.Equals("Lon"))
            {
                this.NotifyPropertyChanged("Lon");
            }
        }

        public double Lon
        {
            get
            {
                return this.model.Lon;
            }
            set
            {
            }
        }

        public double Lat
        {
            get
            {
                return this.model.Lat;
            }
            set
            {
            }
        }
        
        private ICommand settingsCommand;

        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand 
                    = new CommandHandler(() => SettingsOnClick()));
            }
        }

        public void SettingsOnClick()
        {
            this.settings = new Settings();
            this.settings.ShowDialog();     
        }
        
        private ICommand connectCommand;

        public ICommand ConnectCommand {
            get
            {
                return connectCommand ?? (connectCommand 
                    = new CommandHandler(() => ConnectOnClick()));
            }
        }

        public void ConnectOnClick()
        {
            // avoid two connections
            if (!this.isConnected)
            {
                this.isConnected = true;

                // start server, listen to plane by port
                new Thread(delegate () {
                    Info.Instance.Connect(ApplicationSettingsModel.Instance.FlightInfoPort);
                    this.model.Read();
                }).Start();

                // start client, connect plane by ip and port
                new Thread(delegate () {
                    Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, 
                        ApplicationSettingsModel.Instance.FlightCommandPort);
                }).Start();
            }
        }
    }
}
