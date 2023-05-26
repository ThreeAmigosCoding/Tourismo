﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourismo.GUI.Auth;
using Tourismo.GUI.Utility;

namespace Tourismo.Core.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<LoginViewModel>().To<LoginViewModel>();
        }

    }
}
