using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales
{
    public class ScaningABar
    {
        private String barCode;
        public ScaningABar(string barCode)
        {
            this.BarCode = barCode;
        }
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }
        public string GetTheBarCodeScaned()
        {
            switch (barCode)
            {
                case "12345":
                    return ("$7.25");
                 
                case "23456":
                    return ("$12.50");
                   
                case "99999":
                    return ("Error: vara existerar ej");
               
                case "":
                    return ("Error: tom streckkod");
                default:
                    return "0";
            }

        }
   

    }


}

