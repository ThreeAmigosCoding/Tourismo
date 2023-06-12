using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tourismo
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        UserControl prozor;
        public JavaScriptControlHelper(UserControl w)
        {
            prozor = w;
        }

        //public void RunFromJavascript(string param)
        //{
        //    prozor.doThings(param);
        //}
    }
}
