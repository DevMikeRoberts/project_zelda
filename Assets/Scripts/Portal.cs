using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : Collideable   {

    public string nextScene;
    private Player player;
    public LevelEnd EndScreen;

    protected override void OnCollide(Collider2D coll) {

        if (coll.name == "Player")  {
            //Teleport the player to next scene
            GameManager.instance.SaveState();
            player = GameObject.Find("Player").GetComponent<Player>();
            //create level end menu here
            EndScreen.CreateEM();
            //player.endLevel = 1; // should initiate LoadNextLevel; - moved to LevelEnd
        }

    }

}
