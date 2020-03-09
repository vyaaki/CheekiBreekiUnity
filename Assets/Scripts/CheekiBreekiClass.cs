using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekiBreeki
{
    class CheekiBreekiClass
    {
        private const int Alpha = 3;
        private const int Beta = 5;


        private bool DividedBy(int divider, int InputNumber)
        {
            return InputNumber % divider == 0;
        }

        public string CheekiBreekiResult(int InputNumber)
        {
            string resultString = "";

            if (DividedBy(Alpha, InputNumber))
            {
                resultString = "Cheeki";
            }

            if (DividedBy(Beta, InputNumber))
            {
                resultString += "Breeki";
            }

            if(resultString == "")
            {
                return InputNumber.ToString();
            }
            else
            {
                return resultString;
            }

        }
    }
}
