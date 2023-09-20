using UnityEngine;

public class MyStack<T>
{
    T[] arr;
    int top;   // Stack 마지막 원소 위치

    public MyStack(int size)
    {
        top = -1; // Stack 마지막 원소 위치 초기화
        arr = new T[size];
    }

    //데이터 추가
    public void Push(T data)
    {
        if (IsFull()) { return; }

        arr[top+1] = data;
        top++;
        Debug.Log($"MyStack Push: {data}");
    }

    //데이터 출력
    public T Pop()
    {
        if (IsEmpty()) { return default; }

        return arr[top--];
    }

    public void TestPop()
    {
        if (IsEmpty()) { return; }
        Debug.Log($"MyStack Pop: {Pop()}");
    }

    //예외처리
    bool IsFull()
    {
        if ((top + 1) >= arr.Length)
        {
            Debug.Log("Stack 꽉 참");
            return true;
        }
        return false;
    }
    bool IsEmpty()
    {
        if (top < 0)
        {
            Debug.Log("Stack 텅");
            return true;
        }

        return false;
    }
}