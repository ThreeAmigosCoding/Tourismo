using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Tourismo.GUI.Utility
{
    public class ImageNameConverter : IValueConverter
    {
        private const string ResourcePath = "/Tourismo;component/Resources/Images/Travel/"; // Replace with your actual resource path

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imageName)
            {
                string imagePath = $"{ResourcePath}{imageName}"; // Construct the complete image path
                return new Uri(imagePath, UriKind.RelativeOrAbsolute);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
