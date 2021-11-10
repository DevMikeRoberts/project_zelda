using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour //add to empty game object to add to inventory script
{
    public List<Item> items = new List<Item>();

    public void Awake()
    {
        BuildDatabase();
    }
    
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(0,"Golden Key"),
            new Item(1, "Silver Key"),
            new Item(2, "Iron Key")
        };
    }
}
