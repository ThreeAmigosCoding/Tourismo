﻿using Microsoft.Maps.MapControl.WPF;
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
using Tourismo.Core.Model.UserManagement;
using Tourismo.Core.Utility;

namespace Tourismo.GUI.Client
{
    /// <summary>
    /// Interaction logic for TravelsOverviewView.xaml
    /// </summary>
    public partial class TravelsOverviewView : UserControl
    {
        public TravelsOverviewView()
        {
            InitializeComponent();
        }

        //private void MapControl_ViewChangeOnFrame(object sender, MapEventArgs e)
        //{
        //    if (mapControl.ZoomLevel < 7)
        //    {
        //        mapControl.ZoomLevel = 7;
        //    }
        //}

        private void WhenLoaded(object sender, RoutedEventArgs e)
        {
            searchTravelsTb.Focus();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                User user = GlobalStore.ReadObject<User>("LoggedUser");
                if (user != null && user.Role == Role.Client) 
                {
                    HelpProvider.ShowHelp("travels_overview", this);
                }
                //string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
            }
        }

    }
}
