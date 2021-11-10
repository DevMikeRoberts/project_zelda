using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour //
{
    public Item item;
    private Image spriteImage;

    void Awake()
    {
        spriteImage = GetComponent<Image>();
        spriteImage.color = Color.clear; //makes the image transparent initially
    }
    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
        }
        else
        {
            spriteImage.color = Color.clear; //transparent
        }
    }
}
