using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collideable   {

    public string nextScene;
    private Player player;

    protected override void OnCollide(Collider2D coll) {

        if (coll.name == "Player")  {
            //Teleport the player to next scene
            GameManager.instance.SaveState();
            player = GameObject.Find("Player").GetComponent<Player>();

            player.endLevel = 1; // should initiate LoadNextLevel;
        }

    }

}
