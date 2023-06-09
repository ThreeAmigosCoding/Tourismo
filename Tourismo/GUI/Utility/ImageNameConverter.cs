using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Tourismo.GUI.Utility
{
    public class ImageNameConverter : IValueConverter
    {
        private const string ResourcePath = "Resources/Images/"; // Replace with your actual resource path

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imageName)
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectDirectory = baseDirectory.Substring(0, baseDirectory.LastIndexOf("bin", StringComparison.OrdinalIgnoreCase));

                string imagePath = Path.Combine(projectDirectory, ResourcePath, imageName);

                try 
                {
                    return new BitmapImage(new Uri(imagePath));
                }
                catch (Exception ex) 
                {
                    string imagePathDefault = Path.Combine(projectDirectory, ResourcePath, "Travel/travel1.jpg");
                    return new BitmapImage(new Uri(imagePathDefault));
                }
            
            }

            return null;
        }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    }
}
