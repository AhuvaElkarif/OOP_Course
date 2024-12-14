using System;

public struct PointStruct
{
    public int x;
}

public class PointClass
{
    public int x;
}

class Program
{
    static void MeasureStructClassMemory()
    {
        long before_struct = GC.GetAllocatedBytesForCurrentThread();
        PointStruct pointStruct = new PointStruct();
        pointStruct.x = 17;
        long after_struct = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"struct={after_struct - before_struct}");

        long before_class = GC.GetAllocatedBytesForCurrentThread();
        PointClass pointClass = new PointClass();
        pointClass.x = 17;
        long after_class = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"class={after_class - before_class}");
    }

    static void Main(string[] args)
    {
        MeasureStructClassMemory();
    }
}