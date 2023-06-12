using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Agent
{
    class DeleteAttractionFromDetailsCommand : CommandBase
    {
        private AttractionCRUDViewModel _viewModel;
        public DeleteAttractionFromDetailsCommand(AttractionCRUDViewModel viewModel)
        {
            _viewModel = viewModel; ;
        }

        public override void Execute(object? parameter)
        {
            if (_viewModel.DeleteButtonVisibility == Visibility.Visible)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this attraction: "
                + _viewModel.Attraction.Name + "?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.AttractionService.Deactivate(_viewModel.Attraction);
                    MessageBox.Show("Successfully deleted: " + _viewModel.Attraction.Name, "Success");
                    EventBus.FireEvent("AgentAttractionOverview");
                }
   
            }
            
        }
    }
}
