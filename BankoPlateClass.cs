using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankoProgramRefactored
{
    public class BankoPlateClass
    {
        public string plate { get; set; }
        public string row { get; set; }
        public int Col1 { get; set; }
        public int Col2 { get; set; }
        public int Col3 { get; set; }
        public int Col4 { get; set; }
        public int Col5 { get; set; }
        public int Col6 { get; set; }
        public int Col7 { get; set; }
        public int Col8 { get; set; }
        public int Col9 { get; set; }
        public int[] column => new int[] { Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9 };
    }
}
