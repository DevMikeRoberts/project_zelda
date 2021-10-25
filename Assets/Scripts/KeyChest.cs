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
            Debug.Log("Grant Key #" + keyNum);

        }



    }



}
