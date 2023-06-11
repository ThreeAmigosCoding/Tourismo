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

namespace Tourismo.GUI.Navigation
{
    /// <summary>
    /// Interaction logic for ClientHomeView.xaml
    /// </summary>
    public partial class ClientHomeView : UserControl
    {

        private int selectedNavItem;
        private Dictionary<int, RadioButton> navItems;

        public ClientHomeView()
        {
            InitializeComponent();
            selectedNavItem = 0;
            initializeDict();
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.PreviewKeyDown += OnKeyDown;
        }

        private void HomeView_Unloaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.PreviewKeyDown -= OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.Up)
            {
                shiftUp();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.Down)
            {
                shiftDown();
            }
            else if (e.Key == Key.F11) 
            {
                selectedNavItem = 3;
                navItems[selectedNavItem].IsChecked = true;
                if (navItems[selectedNavItem].Command != null)
                    navItems[selectedNavItem].Command.Execute(new object());
            }

        }

        private void shiftUp()
        {
            if (selectedNavItem > 0)
            {
                selectedNavItem--;
                navItems[selectedNavItem].IsChecked = true;
                if (navItems[selectedNavItem].Command != null)
                    navItems[selectedNavItem].Command.Execute(new object());
            }
        }

        private void shiftDown()
        {
            if (selectedNavItem < 3)
            {
                selectedNavItem++;
                navItems[selectedNavItem].IsChecked = true;
                if (navItems[selectedNavItem].Command != null)
                    navItems[selectedNavItem].Command.Execute(new object());
            }
        }

        private void initializeDict()
        {
            navItems = new Dictionary<int, RadioButton>();
            navItems.Add(0, ClientTravelsNav);
            navItems.Add(1, ClientReservationsNav);
            navItems.Add(2, ClientHistoryNav);
            navItems.Add(3, ClientHelpNav);
        }


        private void HandleRadioButtonClick(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            int parameter = Convert.ToInt32(radioButton.Tag);

            selectedNavItem = parameter;
        }
    }
}
