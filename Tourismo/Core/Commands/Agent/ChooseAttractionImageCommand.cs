using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;

namespace Tourismo.Core.Commands.Agent
{
    class ChooseAttractionImageCommand : CommandBase
    {
        private AttractionCRUDViewModel _viewModel;
        public ChooseAttractionImageCommand(AttractionCRUDViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {

                string imagePath = openFileDialog.FileName;
                string imageName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imagePath);

                string destinationPath = Path.Combine("../../../Resources/Images/TouristAttraction/", imageName);
                File.Copy(imagePath, destinationPath, true);

                _viewModel.Attraction.ImagePath = "TouristAttraction/" + imageName;
            }
        }
    }
}
