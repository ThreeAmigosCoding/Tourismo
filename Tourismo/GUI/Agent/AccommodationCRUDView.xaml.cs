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
using Tourismo.GUI.Utility;

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

        private async void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Pin.Visibility = Visibility.Visible;
            // Disables the default mouse double-click action.
            e.Handled = true;

            // Determin the location to place the pushpin at on the map.

            Location location = new Location(Pin.Location);

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(mapControl);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = mapControl.ViewportPointToLocation(mousePosition);

            // The pushpin to add to the map.
            Pin.Location = pinLocation;

            // Adds the pushpin to the map.
            string response = await MapUtils.GetAddressFromLocation(Pin.Location);

            AddressTb.Text = response;
            if (response != "" && response.Split(",")[0] == "")
            {
                AddressTb.Text = response.Split(",")[1];
                if (accommodationNameTb.Text != "")
                    AddressTb.Text = accommodationNameTb.Text + ", " + response.Split(",")[1];
            }
            else if (response == "")
            {
                Pin.Location = location;
            }
        }
         
        private void WhenLoaded(object sender, RoutedEventArgs e)
        {
            accommodationNameTb.Focus();
        }
    }
}
