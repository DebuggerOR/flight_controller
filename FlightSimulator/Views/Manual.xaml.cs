using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using FlightSimulator.ViewModels.Windows;

namespace FlightSimulator.Views
{
    public partial class Manual : UserControl
    {
        public Manual()
        {
            InitializeComponent();
            this.DataContext = new ManualViewModel();
        }
    }
}
