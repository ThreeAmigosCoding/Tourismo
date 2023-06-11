﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.Core.Utility;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Commands.Agent
{
    class SwitchToTravelCRUD : CommandBase
    {
        public override void Execute(object? parameter)
        {
            string mode = (parameter as string)?.ToLower(); 
            GlobalStore.AddObject("TravelCRUDMode", mode);
            EventBus.FireEvent("SwitchToTravelCRUD");
        }

    }
}
