using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourismo.Core.Model.Helper
{
    public class Summarry
    {

        private int _totalSold;
        private double _totalEarned;

        public int TotalSold { get => _totalSold; }
        public double TotalEarned { get => _totalEarned; }


        public Summarry(int totalSold, double totalEarned) 
        {
            _totalSold = totalSold;
            _totalEarned = totalEarned;
        }

    }
}
