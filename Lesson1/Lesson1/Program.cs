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
    static void ModifyStruct(PointStruct p)
    {
        p.x += 10;
        p.y += 10;
    }

    static void ModifyClass(PointClass p)
    {
        p.x += 10;
        p.y += 10;
    }

    public static void MemoryAllocationExperiment()
    {
        long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

        int[] intArray = new int[1000];
        long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

        double[] doubleArray = new double[1000];
        long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

        string[] stringArray = new string[1000];
        long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

        PointStruct[] structArray = new PointStruct[1000];
        long afterStructArray = GC.GetAllocatedBytesForCurrentThread();

        PointClass[] classArray = new PointClass[1000];
        for (int i = 0; i < classArray.Length; i++)
        {
            classArray[i] = new PointClass { x = i };
        }
        long afterClassArray = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
        Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
        Console.WriteLine($"Double Array Allocation: {afterDoubleArray - afterIntArray} bytes");
        Console.WriteLine($"String Array Allocation: {afterStringArray - afterDoubleArray} bytes");
        Console.WriteLine($"Struct Array Allocation: {afterStructArray - afterStringArray} bytes");
        Console.WriteLine($"Class Array Allocation: {afterClassArray - afterStructArray} bytes");
    }

    static int RecursiveMethod(int depth, int localArraySize)
    {
        // TODO: Implement a recursive method that:
        // 1. Creates a local byte array of specified size
        byte[] localArray = new byte[localArraySize];
        // משתנים מקומיים נוספים
        int localVariable1 = 0;
        int localVariable2 = 0;
        // 2. Prints current recursion depth
        Console.WriteLine($"Current depth: {depth}");
        // 3. Recursively calls itself, incrementing depth
        try
        {
            return RecursiveMethod(depth + 1, localArraySize);
        }
        catch (StackOverflowException)
        {
            return depth;
        }
    }

    static int[] ExpandArray(int[] array)
    {
        int[] oldArray = array;
        array = new int[oldArray.Length * 2];
        for (int i = 0; i < oldArray.Length; i++)
        {
            array[i] = oldArray[i];
            array[i + oldArray.Length] = oldArray[i];
        }
        return array;
    }

    static void Main(string[] args)
    {
        #region Lesson 1
        // Ex 1
        PointStruct pointStruct = new PointStruct { x = 10, y = 20 };
        Console.WriteLine($"Before ModifyStruct: X={pointStruct.x}, Y={pointStruct.y}");
        ModifyStruct(pointStruct);
        Console.WriteLine($"After ModifyStruct: X={pointStruct.x}, Y={pointStruct.y}");

        PointClass pointClass = new PointClass { x = 10, y = 20 };
        Console.WriteLine($"Before ModifyClass: X={pointClass.x}, Y={pointClass.y}");
        ModifyClass(pointClass);
        Console.WriteLine($"After ModifyClass: X={pointClass.x}, Y={pointClass.y}");

        //Ex 2
        int[] arraySizes = { 100, 1000, 10000 };
        foreach (int size in arraySizes)
        {
            Console.WriteLine($"\nExperiment with local array size: {size} bytes");
            try
            {
                int maxDepth = RecursiveMethod(0, 10000);
                Console.WriteLine($"Maximum recursion depth: {maxDepth}");
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Stack overflow occurred!");
            }
        }

        // Ex 3
        MemoryAllocationExperiment();

        // Ex 4
        int[] a = { 1, 2, 3 };
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine(a[i]);
        }
        a = ExpandArray(a);
        Console.WriteLine();
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine(a[i]);
        }
    }
    #endregion


}

