using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class OperationTable
    {
        public int input;
        public int [,] results = new int[10,10];

        public OperationTable(int input)
        {
            this.input = input;
        }

        public void Calculate()
        {
            for (int i = 1; i <= results.GetLength(0); i++)
            {
                for (int j = 1; j <= results.GetLength(1); i++)
                {
                    results[i, j] = i * j;
                }
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); i++)
                {
                    res += results[i,j].ToString() + " ";    
                }
                res += "\n";
            }
            return res;
        }
    }
}
