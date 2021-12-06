using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverM;
    CanvasGroup GameOverCG;
    private GameObject LevelLoader;

    void Start()
    {
        //GameOverM = GameObject.Find("gameOver");
        GameOverCG = GameOverM.GetComponent<CanvasGroup>();
        LevelLoader = GameObject.Find("LevelLoader");
    }
        
    void Update()
    {
        
    }

    public void gameOverStart()
    {
        StartCoroutine(FadeIn());
    }
    public void Restart()
    {
        LevelLoader.GetComponent<LevelLoader>().ReloadLevel();
    }
    public void exitToMain()
    {
        LevelLoader.GetComponent<LevelLoader>().LoadMainMenu();
    }
    IEnumerator FadeIn()
    {
        // loop over 2 seconds
        for (float i = 0; i <= 2; i += Time.deltaTime)
        {
            GameOverCG.alpha = i/2;
            yield return null;
        }
    }
}
