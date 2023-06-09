﻿using System;
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
    /// Interaction logic for TravelCRUDView.xaml
    /// </summary>
    public partial class TravelCRUDView : UserControl
    {

        public TravelCRUDView()
        {
            InitializeComponent();
        }

        private void WhenLoaded(object sender, RoutedEventArgs e)
        {
            travelNameTb.Focus();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("travel_crud", this);
        }
    }
}
