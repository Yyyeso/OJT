using System;
using System.Text;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        SortTest(new MyQuickSort()); // MyQuickSort MyMergeSort MyRadixSort
        //SortTest(new MyMergeSort(), SortOrderType.Descending);
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
        MyPriorityQueue<string> ascendingPriorityQueue = new(5, SortOrderType.Ascending);
        ascendingPriorityQueue.Enqueue("첫째", 1);
        ascendingPriorityQueue.Enqueue("넷째", 4);
        ascendingPriorityQueue.Enqueue("둘째", 2);
        ascendingPriorityQueue.Enqueue("셋째", 3);
        ascendingPriorityQueue.Enqueue("다섯째", 5);

        ascendingPriorityQueue.TestDequeue();
        ascendingPriorityQueue.TestDequeue();
        ascendingPriorityQueue.TestDequeue();
        ascendingPriorityQueue.TestDequeue();
        ascendingPriorityQueue.TestDequeue();

        print("==============================================");

        MyPriorityQueue<string> descendingPriorityQueue = new(5, SortOrderType.Descending);
        descendingPriorityQueue.Enqueue("첫째", 1);
        descendingPriorityQueue.Enqueue("넷째", 4);
        descendingPriorityQueue.Enqueue("둘째", 2);
        descendingPriorityQueue.Enqueue("셋째", 3);
        descendingPriorityQueue.Enqueue("다섯째", 5);

        descendingPriorityQueue.Peek(); print("Peek");
        descendingPriorityQueue.Peek(); print("Peek");

        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();

        print("==============================================");

        descendingPriorityQueue.Enqueue("첫째", 1);
        descendingPriorityQueue.Enqueue("넷째", 4);
        descendingPriorityQueue.Enqueue("둘째", 2);
        descendingPriorityQueue.Enqueue("셋째", 3);
        descendingPriorityQueue.Enqueue("다섯째", 5);

        descendingPriorityQueue.Dequeue(); print("Dequeue");
        descendingPriorityQueue.Dequeue(); print("Dequeue");

        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
        descendingPriorityQueue.TestDequeue();
    }
    #endregion

    #region 정렬 테스트
    int[] arr = new int[] { 1, 9, 2, 4, 5, 7, 6, 8, 0 };
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
