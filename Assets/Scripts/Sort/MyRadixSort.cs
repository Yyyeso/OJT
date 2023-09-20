using System;
using System.Collections.Generic;

public class MyRadixSort : ISort
{
    const int radix = 10;
    static Action<List<int>[]> SetOrderType = null;


    public void Sort(int[] arr, SortOrderType type = SortOrderType.Ascending)
    {
        RadixSort(arr, type);
    }
    public static void RadixSort(int[] arr, SortOrderType type = SortOrderType.Ascending)
    {
        switch (type)
        {
            case SortOrderType.Ascending:
                SetOrderType = Ascending;
                break;
            case SortOrderType.Descending:
                SetOrderType = Descending;
                break;
            default:
                SetOrderType = Ascending;
                break;
        }

        FindMaxValue(arr, out int max);
        CountDigits(max, out int maxDigits);

        for (int i = 0; i < maxDigits; i++) // 배열 안에서 가장 큰 수의 자릿수만큼 반복
        {                                   // (가장 큰 수가 562일 경우 3번 반복)
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

        while (max != 0) // [ max: 562 | count: 0 ]
        {
            max = (int)(max * 0.1f); //   [ max: (int)56.2 | count: 1 ] 
            count++;                 // → [ max: (int)5.6  | count: 2 ]
        }                            // → [ max: (int)0.5  | count: 3 ]

        maxDigits = count; // [ maxDigits: 3 ]
    }

    static void CountingSort(int[] arr, int digits)
    {
        #region 버킷 생성
        var buckets = new List<int>[radix]; // 버킷 10개 담을 배열 생성

        for (int i = 0; i < radix; i++) // 버킷 10개 인스턴스 생성
        {
            int idx = i;
            buckets[idx] = new();
        }
        #endregion

        foreach (int item in arr)
        {
            int digit = GetDigit(item, digits);
            //GetDigit: item이 458, digits가 1일 때 5 반환
            buckets[digit].Add(item);
        }

        SetOrderType(buckets);
        int index = 0;

        foreach (List<int> bucket in buckets)
        {
            foreach (int num in bucket)
            {
                arr[index++] = num;
            }
        }
    }

    static void Ascending(List<int>[] buckets) { }

    static void Descending(List<int>[] buckets) { Array.Reverse(buckets); }

    static int GetDigit(int num, int digitIdx) // num의 타깃(digitIdx+1) 자릿수의 값 구하는 식
    {                                          // num: 8562/ digitIdx: 0 (1의 자리) → 2 
        int digit = (num / (int)Math.Pow(10, digitIdx)) % 10;
        // Math.Pow(a, b) → a의 b 제곱
        #region digit 식 설명
        // [ 10의 0승: 1 ] → [ 10의 1승: 10] → [ 10의 2승: 100 ] ……

        // 1. (num / (int)Math.Pow(10, digitIdx))
        //    → num값에서 (int)Math.Pow(10, digitIdx)의 0만큼 버림
        //    → num이 8562, digitIdx가 2일 때 
        //    → (int)Math.Pow(10, 2)
        //    → 10의 2승: 100
        //    → 0 두 개
        //    → 8562에서 끝자리 두 개 버림 (62 버림)
        // 2. % 10
        //    → 끝자리 취득
        //    → 62 버리고 남은 85에서 5 취득
        #endregion
        return digit;
    }
}