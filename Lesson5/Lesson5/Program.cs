using System;

namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ex1 
            // Create fractions
            Fraction frac1 = new Fraction(3, 4); // 3/4
            Fraction frac2 = new Fraction(2, 3); // 2/3

            Console.WriteLine("Fractions:");
            Console.WriteLine($"Fraction 1: {frac1}");
            Console.WriteLine($"Fraction 2: {frac2}");

            // Addition
            Fraction sum = frac1 + frac2;
            Console.WriteLine($"\n{frac1} + {frac2} = {sum}");

            // Subtraction
            Fraction difference = frac1 - frac2;
            Console.WriteLine($"{frac1} - {frac2} = {difference}");

            // Multiplication
            Fraction product = frac1 * frac2;
            Console.WriteLine($"{frac1} * {frac2} = {product}");

            // Division
            Fraction quotient = frac1 / frac2;
            Console.WriteLine($"{frac1} / {frac2} = {quotient}");

            // Comparison
            Console.WriteLine($"\nComparison:");
            Console.WriteLine($"{frac1} > {frac2} = {frac1 > frac2}");
            Console.WriteLine($"{frac1} < {frac2} = {frac1 < frac2}");
            Console.WriteLine($"{frac1} == {frac2} = {frac1 == frac2}");
            Console.WriteLine($"{frac1} != {frac2} = {frac1 != frac2}");

            // Edge case: Fraction simplification
            Fraction frac3 = new Fraction(8, 12); // Simplifies to 2/3
            Console.WriteLine($"\nSimplified Fraction: {frac3}");

            // Edge case: Division by zero
            try
            {
                Fraction frac4 = new Fraction(1, 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            #endregion


            #region Ex2
            List<Fraction> row_values = new List<Fraction>();
            for (int i = 1; i <= 12; i++)
            {
                row_values.Add(new Fraction(i , 12));
            }
            List<Fraction> col_values = new List<Fraction>();
            for (int i = 1; i <= 12; i++)
            {
                col_values.Add(new Fraction(i, 12));
            }

            GenericOperationTable<Fraction> t1 = new GenericOperationTable<Fraction>(row_values, col_values, (x, y) => x + y);
            t1.Calculate();
            t1.Print();
            #endregion
        }
    }
}
