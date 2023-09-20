using UnityEngine;

public class MyCircularQueue<T>
{
    T[] arr;
    int rear = 0, front = 0, count = 0;
    const int defaultSize = 5;

    public MyCircularQueue()
    {
        arr = new T[defaultSize];
    }
    public MyCircularQueue(int size)
    {
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

        rear = CircularIndex(rear);
        count++;
        arr[rear] = data;
        Debug.Log($"MyCircularQueue Enqueue: {data}");
    }

    //데이터 출력
    public T Dequeue()
    {
        if (IsEmpty()) { return default; }

        front = CircularIndex(front);
        count--;
        return arr[front];
    }

    public void TestDequeue()
    {
        if (IsEmpty()) { return; }
        Debug.Log($"MyCircularQueue Dequeue: {Dequeue()}");
    }

    int CircularIndex(int value)
    {
        return (value + 1) % arr.Length;
    }

    //예외처리
    bool IsFull()
    {
        if ((CircularIndex(rear) == front))
        {
            Debug.Log("Queue 꽉 참");
            return true;
        }
        return false;
    }
    bool IsEmpty()
    {
        if (front == rear)
        {
            Debug.Log("Queue 텅");
            return true;
        }

        return false;
    }
}