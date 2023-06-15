using System.Linq;
using SortAlgorithms;
using System.Diagnostics;

int[] arr = { 1, 4, 3, 3, 9, 8, 7, 2, 5, 0 };
Random random = new Random();
arr = Enumerable
        .Repeat(0, 300)
        .Select(i => random.Next(0, 100000))
        .ToArray();

Stopwatch stopwatch = Stopwatch.StartNew();

//SortAlgorithms.SortAlgorithms.BubbleSort(arr); // 100000, 32000ms
//SortAlgorithms.SortAlgorithms.SelectionSort(arr); // 100000, 8000ms
//SortAlgorithms.SortAlgorithms.InsertionSort(arr); // 100000, 5200ms
//SortAlgorithms.SortAlgorithms.MergeSort(arr); // 100000, 12000 ms
SortAlgorithms.SortAlgorithms.QuickSort(arr);
stopwatch.Stop();
for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"{arr[i]},");
}
Console.WriteLine();
Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds} ms ");