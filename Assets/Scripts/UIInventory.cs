using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour //add to InvPanel
{
    public List<UIItem> uIItems = new List<UIItem>();
    public GameObject slot;
    public Transform slotPanel;
    public int slotNumber = 9;

    private void Awake()
    {
        for(int i = 0; i <slotNumber; i++)
        {
            GameObject instance = Instantiate(slot);
            instance.transform.SetParent(slotPanel);
            instance.transform.localScale = new Vector3(1, 1, 1);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == item), null);
    }
}