using System;

public class ArrayProcessor
{
    // Generic method to process the array with a provided processor (action)
    public static void ProcessArray(int[] array, Action<int> processor)
    {
        foreach (int item in array)
        {
            processor(item);
        }
    }
}

public class SumCalculator
{
    private int _sum;

    public void AddToSum(int number)
    {
        _sum += number;
    }

    public int GetSum()
    {
        return _sum;
    }
}

public class MaxCalculator
{
    private int _max;

    public void FindMax(int number)
    {
        if (number > _max)
        {
            _max = number;
        }
    }

    public int GetMax()
    {
        return _max;
    }
}

public class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Sum calculation
        var sumCalculator = new SumCalculator();
        ArrayProcessor.ProcessArray(numbers, sumCalculator.AddToSum);
        int totalSum = sumCalculator.GetSum();
        Console.WriteLine($"Total sum: {totalSum}");

        // Max value calculation
        var maxCalculator = new MaxCalculator();
        ArrayProcessor.ProcessArray(numbers, maxCalculator.FindMax);
        int maxValue = maxCalculator.GetMax();
        Console.WriteLine($"Max value: {maxValue}");
    }
}
