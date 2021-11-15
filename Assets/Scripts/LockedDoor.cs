using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Collideable   {

    public Sprite openDoor;
    public int keyToUnlock;
    private Player player;


    protected override void OnCollide(Collider2D coll) {

        player = GameObject.Find("Player").GetComponent<Player>();

        if (coll.name == "Player") {
            int keyHas = player.keyInventory;
            if (keyHas == keyToUnlock) {
                GetComponent<SpriteRenderer>().sprite = openDoor;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }

}
