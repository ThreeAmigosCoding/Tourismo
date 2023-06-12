using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;

namespace Tourismo.Core.Commands.Agent
{
    public class AttractionReceivedCommand : CommandBase
    {
        private AttractionDragDropViewModel _viewModel;

        public AttractionReceivedCommand(AttractionDragDropViewModel viewModel)
        {
            _viewModel = viewModel;
        }   

        public override void Execute(object? parameter)
        {
            _viewModel.AddAttraction(_viewModel.IncomingAttraction);
        }
    }
}
