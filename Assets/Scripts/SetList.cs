using System.Collections.Generic;
using UnityEngine;


public class SetList<T>
{
    private List<T> list;
    public T this[int index]
    {
        get { return list[index]; }
    }

    public SetList()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        foreach (var t in list)
        {
            if (item.Equals(t))
            {
                return;
            }
        }

        list.Add(item);
    }

    public void Remove(T item)
    {
        list.Remove(item);
    }

    public int Count()
    {
        return list.Count;
    }
}
