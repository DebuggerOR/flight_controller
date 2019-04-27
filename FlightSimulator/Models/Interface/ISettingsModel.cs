using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FlightSimulator.Models.Interface
{
    public interface ISettingsModel
    {
        // The Port of the Flight Server
        int FlightInfoPort { get; set; }

        // The Port of the Flight Server
        int FlightCommandPort { get; set; }

        // The IP Of the Flight Server
        string FlightServerIP { get; set; }          

        void SaveSettings();
        void ReloadSettings();
    }
}
