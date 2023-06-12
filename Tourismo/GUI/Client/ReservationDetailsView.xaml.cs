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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tourismo.GUI.Client
{
    /// <summary>
    /// Interaction logic for ReservationDetailsView.xaml
    /// </summary>
    public partial class ReservationDetailsView : UserControl
    {
        public ReservationDetailsView()
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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("reservation_details", this);
        }

        private void ScrollToAttractions(object sender, RoutedEventArgs e)
        {
            AttractionsPanel.BringIntoView();
        }

        private void ScrollToAccommodation(object sender, RoutedEventArgs e)
        {
            AccommodationPanel.BringIntoView();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;

            DropShadowEffect dropShadow = new DropShadowEffect()
            {
                ShadowDepth = 4,
                Direction = -45,
                Color = Colors.Black,
                Opacity = 0.6
            };
            stackPanel.Effect = dropShadow;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            stackPanel.Effect = null;
        }

        private void RestaurantDetails(object sender, RoutedEventArgs e)
        {

        }
    }
}
