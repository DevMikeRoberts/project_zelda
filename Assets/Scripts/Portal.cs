using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collideable   {

    public string nextScene;

    protected override void OnCollide(Collider2D coll) {

        if (coll.name == "Player")  {
            //Teleport the player to next scene
            GameManager.instance.SaveState();
            string sceneName = nextScene;
            SceneManager.LoadScene(sceneName);

        }

    }

}
