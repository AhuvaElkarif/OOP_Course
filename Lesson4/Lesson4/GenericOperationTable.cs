using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class GenericOperationTable<T>
    {
        // the followng line defines a _type_ op_func
        public delegate T OpFunc(T x, T y);

        // the following line defines a variable of type op_func
        public OpFunc op;
        List<T> row_values;
        List<T> col_values;
        public T[,] results;


        public GenericOperationTable(List<T> _row_values, List<T> _col_values, OpFunc _op)
        {
            row_values = _row_values;
            col_values = _col_values;
            op = _op;
            results = new T[row_values.Count, col_values.Count];
        }

        public void Calculate()
        {
            for (int i = 0; i < row_values.Count; i++)
            {
                for (int j = 0; j < col_values.Count; j++)
                {
                    results[i, j] = op(row_values[i], col_values[j]);
                }
            }
        }

        public void Print()
        {
            // Find the maximum width needed for any value (row, col, or results entry)
            int maxWidth = Math.Max(
                Math.Max(
                    row_values.Max(v => v.ToString().Length),
                    col_values.Max(v => v.ToString().Length)
                ),
                results.Cast<T>().Max(v => v.ToString().Length)
            ) + 2; // Add padding for spacing

            // Print the column headers
            Console.Write(new string(' ', maxWidth)); // Empty space for the row header
            foreach (var col in col_values)
            {
                Console.Write(col.ToString().PadLeft(maxWidth));
            }
            Console.WriteLine();

            // Print the rows
            for (int i = 0; i < row_values.Count; i++)
            {
                Console.Write(row_values[i].ToString().PadLeft(maxWidth)); // Row header
                for (int j = 0; j < col_values.Count; j++)
                {
                    Console.Write(results[i, j].ToString().PadLeft(maxWidth)); // results entry
                }
                Console.WriteLine();
            }
        }

    }
}
