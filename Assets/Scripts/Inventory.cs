using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour // add to player
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    void Start()
    {

    }
    void Update()
    {
        
    }

    public void Pickup(int id)
    {
        Item pickupItem = itemDatabase.GetItem(id);
        characterItems.Add(pickupItem);
        inventoryUI.AddNewItem(pickupItem);
    }

    public void Pickup(string name)
    {
        Item pickupItem = itemDatabase.GetItem(name);
        characterItems.Add(pickupItem);
        inventoryUI.AddNewItem(pickupItem);
    }

    public bool Check(int id)
    {
        if(characterItems.Find(item => item.id == id) != null)
        {
            return true;
        }
        else { return false; }
    }

    public bool Check(string name)
    {
        if (characterItems.Find(item => item.title == name) != null)
        {
            return true;
        }
        else { return false; }
    }

    public void RemoveItem(int id)
    {
        if (Check(id))
        {
            Item removeI = characterItems.Find(item => item.id == id);
            characterItems.Remove(removeI);
            inventoryUI.RemoveItem(removeI);
        }
    }

    public void RemoveItem(string name)
    {
        if (Check(name))
        {
            Item removeI = characterItems.Find(item => item.title == name);
            characterItems.Remove(removeI);
            inventoryUI.RemoveItem(removeI);
        }
    }
}
