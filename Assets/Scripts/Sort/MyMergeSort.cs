public enum SortOrderType
{
    /// <summary> 1 → 2 → 3 → 4 → …… </summary>
    Ascending,
    /// <summary> 10 → 9 → 8 → 7 → …… </summary>
    Descending
}

public class MyMergeSort : ISort
{
    static System.Func<int, int, bool> Compare = null;


    public void Sort(int[] arr, SortOrderType type = SortOrderType.Ascending)
    {
        MergeSort(arr, type);
    }
    public static void MergeSort(int[] arr, SortOrderType type = SortOrderType.Ascending)
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
        MergeSort(arr, 0, arr.Length - 1);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
    }

    static void Merge(int[] arr, int left, int middle, int right)
    {
        int[] arrLeft = new int[middle - left + 1];
        int[] arrRight = new int[right - middle];

        // 왼쪽 배열에 원본 복사
        for (int i = 0; i < arrLeft.Length; i++)
        {
            arrLeft[i] = arr[left + i];
        }

        // 오른쪽 배열에 원본 복사
        for (int j = 0; j < arrRight.Length; j++)
        {
            arrRight[j] = arr[middle + 1 + j];
        }

        int k = left;
        int p = 0;
        int q = 0;

        // 비교(정렬)
        while ((p < arrLeft.Length) && (q < arrRight.Length))
        {
            if (Compare(arrLeft[p], arrRight[q]))
            {
                arr[k] = arrLeft[p++];
            }
            else
            {
                arr[k] = arrRight[q++];
            }

            k++;
        }

        // 나머지 복사
        while (p < arrLeft.Length)
        {
            arr[k++] = arrLeft[p++];
        }
        while (q < arrRight.Length)
        {
            arr[k++] = arrRight[q++];
        }
    }

    /// <summary> 1 → 2 → 3 → 4 → …… </summary>
    static bool Ascending(int a, int b) { return a <= b; }

    /// <summary> 10 → 9 → 8 → 7 → …… </summary>
    static bool Descending(int a, int b) { return a >= b; }
}
