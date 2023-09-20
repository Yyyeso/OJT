using UnityEngine;

public class MyQueue<T>
{
    T[] arr;
    int rear;   // Queue 마지막 원소 위치
    int front;  // Queue 첫번째 원소 위치
    int count = 0;
    const int defaultSize = 5;


    public MyQueue()
    {
        rear = -1;
        front = -1;
        arr = new T[defaultSize];
    }

    public MyQueue(int size)
    {
        rear = -1;
        front = -1;
        arr = new T[size];
    }


    public int Count()
    {
        return count;
    }

    //데이터 추가
    public void Enqueue(T data)
    {
        if (IsFull()) { return; }

        count++;
        arr[++rear] = data;
        Debug.Log($"MyQueue Enqueue: {data}");
    }

    //데이터 출력
    public T Dequeue()
    {
        if (IsEmpty()) { return default; }

        count--;
        return arr[++front];
    }

    public void TestDequeue()
    {
        if (IsEmpty()) { return; }
        Debug.Log($"MyQueue Dequeue: {Dequeue()}");
    }

    //예외처리
    bool IsFull()
    {
        if (rear + 1 >= arr.Length)
        {
            Debug.Log($"Queue 꽉 참");
            return true;
        }
        return false;
    }
    bool IsEmpty()
    {
        if (rear == front)
        {
            Debug.Log($"Queue 텅");
            return true;
        }

        return false;
    }
}