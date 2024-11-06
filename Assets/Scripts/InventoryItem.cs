using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public int ID;
    public string name;
    public int value;
    public InventoryItem(int ID, string name, int value) 
    {
        this.ID = ID;
        this.name = name;
        this.value = value;
    }

    public override string ToString()
    {
        return "ID: "+ID+" Name: "+  name +" Value: "+value;
    }
}
