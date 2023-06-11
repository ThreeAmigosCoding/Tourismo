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
    class ChooseTravelImageCommand : CommandBase
    {
        private TravelCRUDViewModel _viewModel;
        public ChooseTravelImageCommand(TravelCRUDViewModel viewModel)
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

                string destinationPath = Path.Combine("../../../Resources/Images/Travel/", imageName);
                File.Copy(imagePath, destinationPath, true);

                _viewModel.Travel.ImagePath = "Travel/" + imageName;
            }
        }
    }
}
