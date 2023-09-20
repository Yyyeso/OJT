using System;
using UnityEngine.Events;

public interface ISort
{
    void Sort(int[] arr, SortOrderType type = SortOrderType.Ascending);
}
