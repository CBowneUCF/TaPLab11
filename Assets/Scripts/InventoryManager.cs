using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>()
    {
        new InventoryItem(0,"pop",6),
        new InventoryItem(1,"soda",7),
        new InventoryItem(2,"sparkly",4),
        new InventoryItem(3,"cola",8),
    };
    private void Start()
    {
        string list="";
        foreach(var item in items)
        {
            list += item.ToString()+"\n";
        }
        print(list);

        list = "Quicksorted\n";
        QuickSortByValue();
        foreach (var item in items)
        {
            list += item.ToString() + "\n";
        }
        print(list);

        print("Trying to find Pop :" + LinearSearchByName("pop"));
        print("Trying to find ID 1 :"+ BinarySearchByID(1));

    }
    public InventoryItem LinearSearchByName(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name) return items[i];
        }
        return null;
    }

    public InventoryItem BinarySearchByID(int id)
    {
        return BinarySearchByID(id, items.OrderBy(x=>x.ID) .ToArray());
    }
    InventoryItem BinarySearchByID(int id, InventoryItem[] inv)
    {
        int mid=inv.Length/2;
        if (inv[mid].ID == id)
        {
            return inv[mid];
        }
        if (id < inv[mid].ID)
        {
            return BinarySearchByID(id, items.GetRange(0, inv.Length/2).ToArray());
        }
        else
        {
            return BinarySearchByID(id, items.GetRange(mid+1, inv.Length / 2).ToArray());
        }
    }

   

    public void QuickSortByValue()
    {
        QuickSortByValue(0, items.Count-1);
    }
    void QuickSortByValue(int first, int last)
    {
        if (first < last)
        {
            int pivot = Partition(items, first, last);
            QuickSortByValue(first, pivot - 1);
            QuickSortByValue(pivot + 1, last);
        }
    }
    public int Partition(List<InventoryItem> array, int first, int last)
    {
        int pivot = array[last].value;
        int smaller = first;

        for (int element = first; element < last; element++)
        {
            if (array[element].value < pivot)
            {
                element++;
                InventoryItem temporary = array[smaller];
                array[smaller] = array[element];
                array[element] = temporary;
            }
        }
        InventoryItem temporaryNext = array[smaller + 1];
        array[smaller + 1] = array[last];
        array[last] = temporaryNext;

        return smaller + 1;
    }


}
