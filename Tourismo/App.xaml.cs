using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tourismo.Core.Persistence;

namespace Tourismo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                //DatabaseContextSeed.Seed(db);
            }
        }
    }
}
