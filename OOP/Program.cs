using System;

class Program
{
    struct PointStruct
    {
        public int x;
        public int y;
        public int z;
        public int g;
    }

    class PointClass
    {
        public int x;
        public int y;
        public int z;
        public int g;
    }

    // In order to change the struct should sent in ref, else it not changed
    static void ModifyPoint(ref PointStruct p)
    {
        p.x += 10;
        p.y += 10;
        Console.WriteLine($"In Modify Struct p.x= {p.x}, p.y={p.y}");
    }

    static void ModifyClass(PointClass p)
    {
        p.x += 10;
        p.y += 10;
        Console.WriteLine($"In Modify Class p.x= {p.x}, p.y={p.y}");
    }

    static int counter = 0;
    static void Recursion()
    {
        int[] arr = new int[10];
        counter++;
        Console.WriteLine($"Counter: {counter}");
        Recursion();
    }

    static void MeasureMemoryStruct()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();
        PointStruct[] arr = new PointStruct[200];
        long after = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"Memory: {before} - {after} = {after - before}");
    }

    static void MeasureMemoryClass()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();
        PointClass[] arr = new PointClass[200];
        long after = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"Memory: {before} - {after} = {after - before}");
    }

    public static void ModifyArray(int[] arr)
    {
        arr[0] = 999; //Modify original array
        arr = arr = new int[] { 10, 20, 30 }; // only modifies local reference
    }
  
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        PointStruct p = new PointStruct { x = 10, y = 20 };
        ModifyPoint(ref p);
        Console.WriteLine($"p.x= {p.x}, p.y={p.y}");

        PointClass p2 = new PointClass { x = 10, y = 20 };
        ModifyClass(p2);
        Console.WriteLine($"Class p.x= {p2.x}, p.y={p2.y}");

        //Recursion();
        MeasureMemoryStruct();
        MeasureMemoryClass();

        int[] arr = new int[] { 1, 2, 3, 4 };
        Console.WriteLine(string.Join(",", arr));
        ModifyArray(arr);
        Console.WriteLine(string.Join(",", arr));
    }
}
