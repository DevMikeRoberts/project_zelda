using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Collideable   {

    public Sprite openDoor_top;
    public Sprite openDoor_bottom;
    public GameObject child_Object;
    public int keyToUnlock;
    private Player player;


    protected override void OnCollide(Collider2D coll) {

        player = GameObject.Find("Player").GetComponent<Player>();
        Inventory inventory = (Inventory)player.GetComponent(typeof(Inventory));

        if (coll.name == "Player") {
            int keyHas = player.keyInventory;
            if (inventory.Check("Golden Key")){
                GetComponent<SpriteRenderer>().sprite = openDoor_top;
                child_Object.GetComponent<SpriteRenderer>().sprite = openDoor_bottom;
                GetComponent<BoxCollider2D>().enabled = false;
                child_Object.GetComponent<BoxCollider2D>().enabled = false;
                GameManager.instance.ShowText("Door Unlocked!", 20,Color.white, transform.position,Vector3.up * 25, 1.5f);
                inventory.RemoveItem("Golden Key");
            }
        }

    }

}
