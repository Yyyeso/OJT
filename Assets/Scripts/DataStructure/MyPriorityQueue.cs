using System;
using UnityEngine;

public class MyPriorityQueue<T>
{
    private class Node
    {
        public T Data { get; private set; }
        public float Priority { get; private set; } = 0;

        public Node(T data, float priority)
        {
            this.Data = data;
            this.Priority = priority;
        }
    }

    private Node[] heap;
    private int size;
    private Func<float, float, bool> Compare = null;
    public int Count { get { return size; } }


    public MyPriorityQueue(int capacity, SortOrderType type = SortOrderType.Ascending)
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
        heap = new Node[capacity];
        size = 0;
    }


    public void Clear() { size = 0; }

    public void Enqueue(T data, float priority)
    {
        if (size == heap.Length)
        { Resize(); }

        heap[size] = new Node(data, priority);
        HeapifyUp(size++);
    }

    public T Dequeue()
    {
        if (IsEmpty())
        { throw new Exception("Empty Heap"); }

        Node node = heap[0];
        heap[0] = heap[size - 1];
        size--;
        HeapifyDown(0);

        return node.Data;
    }

    public T Peek()
    {
        if (IsEmpty())
        { throw new Exception("Empty Heap"); }

        return heap[0].Data;
    }

    public void TestDequeue()
    {
        if (IsEmpty()) 
        {
            Debug.Log("텅");
            return; 
        }
        Debug.Log($"Dequeue: {Dequeue()}");
    }

    void HeapifyUp(int idx)
    {
        int idxParrent = GetParrent(idx);

        while (Compare(heap[idx].Priority, heap[idxParrent].Priority) && idx > 0)
        {
            Swap(heap, idx, idxParrent);
            idx = idxParrent;
            idxParrent = GetParrent(idx);
        }
    }

    void HeapifyDown(int idx)
    {
        int idxLeftChild = (2 * idx) + 1;
        int idxRightChild = (2 * idx) + 2;
        int idxMax = idx;

        if (idxLeftChild < size && Compare(heap[idxLeftChild].Priority, heap[idxMax].Priority))
        { idxMax = idxLeftChild; }

        if (idxRightChild < size && Compare(heap[idxRightChild].Priority, heap[idxMax].Priority))
        { idxMax = idxRightChild; }

        if (idxMax != idx)
        {
            Swap(heap, idx, idxMax);
            HeapifyDown(idxMax);
        }
    }

    int GetParrent(int idx)
    {
        return (idx - 1) / 2;
    }

    bool IsEmpty() {  return size == 0; }

    void Resize()
    {
        var temp = new Node[heap.Length * 2];
        for (int i = 0; i < heap.Length; i++)
        {
            int idx = i;
            temp[idx] = heap[idx];
        }
        heap = temp;
    }

    void Swap(Node[] arr, int a, int b)
    {
        (arr[b], arr[a]) = (arr[a], arr[b]);
    }

    /// <summary> 1 → 2 → 3 → 4 → …… </summary>
    bool Ascending(float a, float b) { return a < b; }

    /// <summary> 10 → 9 → 8 → 7 → …… </summary>
    bool Descending(float a, float b) { return a > b; }
}
