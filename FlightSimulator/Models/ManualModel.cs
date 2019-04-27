using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSimulator.Communication;

namespace FlightSimulator.Models
{
    class ManualModel
    {
        public void SendCommand(string singleCommand)
        {
            new Thread(delegate ()
                {
                    Commands.Instance.SendCommands(singleCommand);
                }).Start();
        }
    }
}
