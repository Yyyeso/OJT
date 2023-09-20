using System;
using System.Collections.Generic;

public class MyRadixSort : ISort
{
    const int radix = 10;
    static Action<List<int>[], int[]> Compare = null;


    public void Sort(int[] arr, SortOrderType type = SortOrderType.Ascending)
    {
        RadixSort(arr, type);
    }
    public static void RadixSort(int[] arr, SortOrderType type = SortOrderType.Ascending)
    {
        switch (type)
        {
            case SortOrderType.Ascending:
                Compare = Ascending;
                break;
            case SortOrderType.Descending:
                Compare = Descending;
                break;
            default:
                Compare = Ascending;
                break;
        }

        FindMaxValue(arr, out int max);
        CountDigits(max, out int maxDigits);

        for (int i = 0; i < maxDigits; i++)
        {
            CountingSort(arr, i);
        }
    }

    static void FindMaxValue(int[] arr, out int max)
    {
        int maxValue = int.MinValue;

        foreach (int item in arr)
        {
            if (maxValue < item)
                maxValue = item;
        }

        max = maxValue;
    }

    static void CountDigits(int max, out int maxDigits)
    {
        if (max == 0)
        {
            maxDigits = 1;
            return;
        }

        int count = 0;

        while (max != 0)
        {
            max = (int)(max * 0.1f);
            count++;
        }

        maxDigits = count;
    }

    static void CountingSort(int[] arr, int digits)
    {
        var buckets = new List<int>[radix];

        for (int i = 0; i < radix; i++)
        {
            int idx = i;
            buckets[idx] = new();
        }

        foreach (int item in arr)
        {
            int digit = GetDigit(item, digits);
            buckets[digit].Add(item);
        }

        Compare(buckets, arr);
    }

    static void Ascending(List<int>[] buckets, int[] arr)
    {
        int index = 0;

        foreach (List<int> bucket in buckets)
        {
            foreach (int num in bucket)
            {
                arr[index++] = num;
            }
        }
    }

    static void Descending(List<int>[] buckets, int[] arr) // ㅜㅜ
    {
        int index = 0;

        foreach (List<int> bucket in buckets)
        {
            foreach (int num in bucket)
            {
                arr[index++] = num;
            }
        }

        Array.Reverse(arr);
    }

    static int GetDigit(int num, int digitIdx)
    {
        int digit = (num / (int)Math.Pow(10, digitIdx)) % 10;

        return digit;
    }
}
