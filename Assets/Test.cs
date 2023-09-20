using System;
using System.Text;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        SortTest(new MyRadixSort());
    }

    #region 자료구조 테스트
    void Stack()
    {
        MyStack<string> stack = new(5);
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");
        stack.Push("d");
        stack.Push("e");
        stack.Push("f");
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.Push("d");
        stack.Push("e");
        stack.Push("f");
        stack.Push("b");
        stack.Push("c");
        stack.Push("d");
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
        stack.TestPop();
    }

    void Queue()
    {
        MyQueue<int> queue = new(5);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6); // 꽉 참
        queue.Enqueue(7);
        queue.TestDequeue(); // Dequeue
        queue.TestDequeue();
        queue.TestDequeue();
        queue.Enqueue(1); // 그래도 꽉 참
        queue.TestDequeue();
        queue.TestDequeue();
        queue.TestDequeue(); // 텅
        queue.TestDequeue();
        queue.Enqueue(4); // 텅인데 꽉 참
        queue.Enqueue(5);
        queue.Enqueue(6);
        queue.TestDequeue(); // 꽉 찼는데 텅
        queue.Enqueue(4);
    }

    void CircularQueue()
    {
        MyCircularQueue<bool> queue = new();
        queue.Enqueue(true);
        queue.Enqueue(false);
        queue.Enqueue(true);
        queue.Enqueue(false);
        queue.Enqueue(true); // 꽉 참
        queue.Enqueue(false);
        queue.Enqueue(true);
        queue.TestDequeue(); // Dequeue
        queue.TestDequeue();
        queue.TestDequeue();
        queue.Enqueue(true);  // 자리 나서 들어감
        queue.TestDequeue();
        queue.TestDequeue();
        queue.TestDequeue();  // 텅
        queue.Enqueue(false); // 자리 나서 들어감
        queue.Enqueue(true);
        queue.Enqueue(false);
        queue.TestDequeue(); // Dequeue
        queue.Enqueue(false);
    }

    void PriorityQueue()
    {
        print("================= 우선순위 - 오름차순 =================");

        MyPriorityQueue<string> ascending = new(5, SortOrderType.Ascending);
        ascending.Enqueue("첫째", 1); 
        ascending.Enqueue("넷째", 4);
        ascending.Enqueue("둘째", 2);
        ascending.Enqueue("셋째", 3);
        ascending.Enqueue("다섯째", 5);

        ascending.TestDequeue();
        ascending.TestDequeue();
        ascending.TestDequeue();
        ascending.TestDequeue();
        ascending.TestDequeue();

        print("================= 우선순위 - 내림차순 =================");

        MyPriorityQueue<string> descending = new(5, SortOrderType.Descending);
        descending.Enqueue("첫째", 1);
        descending.Enqueue("넷째", 4);
        descending.Enqueue("둘째", 2);
        descending.Enqueue("셋째", 3);
        descending.Enqueue("다섯째", 5);

        descending.Peek(); print("Peek");
        descending.Peek(); print("Peek");

        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();

        print("================= 우선순위 - 내림차순 =================");

        descending.Enqueue("첫째", 1);
        descending.Enqueue("넷째", 4);
        descending.Enqueue("둘째", 2);
        descending.Enqueue("셋째", 3);
        descending.Enqueue("다섯째", 5);

        descending.Dequeue(); print("Dequeue");
        descending.Dequeue(); print("Dequeue");

        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();
        descending.TestDequeue();
    }
    #endregion

    #region 정렬 테스트
    //SortTest(new MyRadixSort()); // MyQuickSort MyMergeSort MyRadixSort
    //SortTest(new MyRadixSort(), SortOrderType.Ascending);
    int[] arr = new int[] { 1, 459, 20, 40, 5, 75, 6, 18, 0 };
    ISort mySort;


    void SortTest(ISort sort) // 정렬 테스트 코드에 전략 패턴 적용
    {
        mySort = sort;
        Sort();
    }
    void SortTest(ISort sort, SortOrderType type) // 오름차순, 내림차순 직접 설정
    {
        mySort = sort;

        print("=====================원본=====================");
        Print(arr);

        print($"=================={mySort}==================");
        mySort.Sort(arr, type);
        Print(arr);
    }

    void Sort()
    {
        print("=====================원본=====================");
        Print(arr);

        print($"=================={mySort}==================");
        mySort.Sort(arr, SortOrderType.Ascending);
        Print(arr);

        print($"=================={mySort}==================");
        mySort.Sort(arr, SortOrderType.Descending);
        Print(arr);
    }
    #endregion

    #region 편의기능
    void Print<T>(T[] arr)
    {
        StringBuilder sb = new();

        foreach (var i in arr)
        {
            sb.Append($"{i}, ");
        }
        sb.Remove(sb.Length - 2, 2);

        print(sb.ToString());
    }
    #endregion
}
