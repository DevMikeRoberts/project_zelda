using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChest : Collectable  {

    public Sprite openChest;
    public int keyNum = 0;
    private Player player;

    protected override void OnCollect() {

        player = GameObject.Find("Player").GetComponent<Player>();

        if (!collected) {

            collected = true;
            GetComponent<SpriteRenderer>().sprite = openChest;
            player.keyInventory = keyNum;
            GameManager.instance.ShowText("Collected Key #" + keyNum + "!", 20,Color.white, transform.position,Vector3.up * 25, 1.5f);
            Debug.Log("Grant Key #" + keyNum);
            Inventory inventory = (Inventory) player.GetComponent(typeof(Inventory));
            inventory.Pickup("Golden Key");
        }



    }



}
