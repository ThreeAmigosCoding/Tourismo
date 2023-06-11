using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Agent;

namespace Tourismo.Core.Commands.Agent
{
    public class AttractionInsertedCommand : CommandBase
    {
        private AttractionDragDropViewModel _viewModel;

        public AttractionInsertedCommand(AttractionDragDropViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.InsertAttraction(_viewModel.InsertedAttraction, _viewModel.TargetAttraction);
        }
    }
}
