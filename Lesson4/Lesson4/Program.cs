using Lesson4;
using System;

public class Program
{
    public static void SortTwo<T>(ref T a, ref T b, Comparison<T> comparison)
    {
        if (comparison(a, b) > 0)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    public static void SortTwo<T>(ref T a, ref T b) where T : IComparable<T>
    {
        if (a.CompareTo(b) > 0)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
    public static void Main()
    {
        #region Ex 1
        //Option A
        int x = 5, y = 3;
        SortTwo(ref x, ref y, (a, b) => a.CompareTo(b));
        Console.WriteLine($"x: {x}, y: {y}"); // Output: x: 3, y: 5

        //Option B
        x = 5;
        y = 3;
        SortTwo(ref x, ref y);
        Console.WriteLine($"x: {x}, y: {y}"); // Output: x: 3, y: 5
        #endregion

        #region Ex2
        List<double> row_values = new List<double>();
        for (int i = 1; i <= 4; i++)
        {
            row_values.Add(1.0 / i);
        }
        List<double> col_values = new List<double>();
        for (int i = 1; i < 5; i++)
        {
            col_values.Add(1.0 / i);
        }
       
        GenericOperationTable<double> t1 = new GenericOperationTable<double>(row_values, col_values, (x, y) => x + y);
        t1.Calculate();
        t1.Print();
        #endregion
    }
}
