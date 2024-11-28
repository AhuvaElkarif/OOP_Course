using System;
using System.Text;

class Program
{
    struct PointStruct
    {
        public int x;
        public int y;
    }
    public static void MeasureStructMemory()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();
        PointStruct pointStruct = new PointStruct();
        long after = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"MeasureStructMemory: Allocated Memory={after - before}");
    }

    public static void MeasureStringMemory()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();
        string s = new string("hello world");
        long after = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before}");
    }

    public static void MeasureMemory()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();
        long after = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before}");
    }

    public static string MeasureStringMemory2()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();

        string str = "";
        for (int i = 1; i <= 100; i++)
        {
            str += i + " ";
        }
        long after = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before}");
        return str;
    }

    public static StringBuilder MeasureStringBuilderMemory()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 1; i <= 100; i++)
        {
            stringBuilder.Append(i + " ");
        }
        long after = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before}");
        return stringBuilder;
    }

    public static void TestGC()
    {
        object obj = new object();
        Console.WriteLine($"Generation before GC {GC.GetGeneration(obj)}");
        GC.Collect(0);
        Console.WriteLine($"Generation after GC of Generation 0: {GC.GetGeneration(obj)}");
    }

    static void Main(string[] args)
    {
        #region Lesson2
        // Ex 1
        MeasureStructMemory();
        // Ex 2
        MeasureStringMemory();
        // Ex 3
        string str = MeasureStringMemory2();
        StringBuilder stringBuilder = MeasureStringBuilderMemory();
        // Ex 4
        TestGC();
        #endregion
    }
}

