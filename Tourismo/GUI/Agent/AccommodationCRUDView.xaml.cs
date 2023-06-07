using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tourismo.GUI.Agent
{
    /// <summary>
    /// Interaction logic for AccommodationCRUDView.xaml
    /// </summary>
    public partial class AccommodationCRUDView : UserControl
    {
        public AccommodationCRUDView()
        {
            InitializeComponent();
        }

        private void MapControl_ViewChangeOnFrame(object sender, MapEventArgs e)
        {
            if (mapControl.ZoomLevel < 7)
            {
                mapControl.ZoomLevel = 7;
            }
        }
    }
}
