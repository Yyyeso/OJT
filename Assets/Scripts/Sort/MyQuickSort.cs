using UnityEngine;

public class MyQuickSort : ISort
{
    static System.Func<int, int, bool> Compare = null;


    public void Sort(int[] arr, SortOrderType type = SortOrderType.Ascending)
    {
        QuickSort(arr, type);
    }

    public static void QuickSort(int[] arr, SortOrderType type = SortOrderType.Ascending)
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
        QuickSort(arr, 0, arr.Length-1);
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }
    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = (left - 1);

        for (int j = left; j <= (right - 1); j++)
        {
            if (Compare(arr[j], pivot))
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, right);
        return (i + 1);
    }

    static void Swap(int[] arr, int a, int b)
    {
        (arr[b], arr[a]) = (arr[a], arr[b]);
    }

    /// <summary> 1 → 2 → 3 → 4 → …… </summary>
    static bool Ascending(int a, int b) { return a <= b; }

    /// <summary> 10 → 9 → 8 → 7 → …… </summary>
    static bool Descending(int a, int b) { return a >= b; }
}
