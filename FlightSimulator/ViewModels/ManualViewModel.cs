using System;
using FlightSimulator.Models;

namespace FlightSimulator.ViewModels.Windows
{
    class ManualViewModel
    {
        private ManualModel model;
        private string rudderePath;
        private string aileronPath;
        private string throttlePath;
		private string elevatorPath;

		public ManualViewModel()
		{
			this.model = new ManualModel();
			this.rudderePath = " /controls/flight/rudder ";
			this.aileronPath = " /controls/flight/aileron ";
            this.elevatorPath = " /controls/flight/elevator ";
            this.throttlePath = " /controls/engines/current-engine/throttle ";
        }
		
        public double Rudder
        {
            set => this.model.SendCommand("set" + this.rudderePath + Convert.ToString(value));
        }
		
		public double Aileron
        {
            set => this.model.SendCommand("set" + this.aileronPath + Convert.ToString(value));
        }
		
		public double Throttle
        {
            set => this.model.SendCommand("set" + this.throttlePath + Convert.ToString(value));
        }
		
        public double Elevator
        {
            set => this.model.SendCommand("set" + this.elevatorPath + Convert.ToString(value));
        }
    }
}
