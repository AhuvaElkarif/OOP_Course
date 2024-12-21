using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Fraction
    {
        public int Counter { get; set; }
        public int Denominator { get; set; }

        public Fraction(int counter, int denominator)
        {

            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");

            int gcd = GCD(Math.Abs(counter), Math.Abs(denominator));
            Counter = counter / gcd;
            Denominator = denominator / gcd;

            if (Denominator < 0)
            {
                Counter = -Counter;
                Denominator = -Denominator;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction
            (
                a.Counter * b.Denominator + b.Counter * a.Denominator,
                a.Denominator * b.Denominator
            );
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction
            (
                a.Counter * b.Denominator - b.Counter * a.Denominator,
                a.Denominator * b.Denominator
            );
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction
            (
                 a.Counter * b.Counter,
                a.Denominator * b.Denominator
            );
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction
            (
               a.Counter * b.Denominator,
               a.Denominator * b.Counter
            );
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.Counter * b.Denominator > b.Counter * a.Denominator;
        }
       
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.Counter * b.Denominator < b.Counter * a.Denominator;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Counter == b.Counter && a.Denominator == b.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Counter}/{Denominator}";
        }
    }
}
