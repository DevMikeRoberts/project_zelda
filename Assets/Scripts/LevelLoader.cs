using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour    {

    public Animator transition;

    private Player player;
    private MainMenu menu;
    public float transitionTime = 1f;

    void Update() {

        if (SceneManager.GetActiveScene().buildIndex != 0 ) {

            player = GameObject.Find("Player").GetComponent<Player>();
            if(player.endLevel == 1) {
                LoadNextLevel();
            }

        }
        else {
            menu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
            if (menu.play == 1) {
                LoadNextLevel();
            }
        }

        
    }

    public void LoadNextLevel() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        Debug.Log("You made it");
    }
    public void LoadMainMenu()
    {
        //StartCoroutine(LoadLevel(0));
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel(int levelIndex) {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        

    }



}
