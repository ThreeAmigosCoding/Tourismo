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

namespace Tourismo.GUI.Client
{
    /// <summary>
    /// Interaction logic for ReservationsOverviewView.xaml
    /// </summary>
    public partial class ReservationsOverviewView : UserControl
    {
        public ReservationsOverviewView()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("reservations_overview", this);
        }
    }
}
