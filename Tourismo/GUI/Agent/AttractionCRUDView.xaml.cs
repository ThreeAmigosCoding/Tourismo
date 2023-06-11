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
    /// Interaction logic for AttractionCRUDView.xaml
    /// </summary>
    public partial class AttractionCRUDView : UserControl
    {
        public AttractionCRUDView()
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

        private void WhenLoaded(object sender, RoutedEventArgs e)
        {
            attractionNameTb.Focus();
        }
    }
}
