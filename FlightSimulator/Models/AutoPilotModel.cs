using System.Threading;
using System.Windows.Media;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;
using FlightSimulator.Communication;

namespace FlightSimulator.Models
{
    class AutoPilotModel
    {
        public void SendCommands(string input, AutoPilotViewModel vm)
        {
            // open new thread to avoid idle
            new Thread(delegate ()
                {
                    Commands.Instance.SendCommands(input);
                    vm.Background = Brushes.White;
                }).Start();
        }
    }
}

