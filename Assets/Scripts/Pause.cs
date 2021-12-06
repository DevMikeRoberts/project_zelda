using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseM;
    public Image PauseMBG;
    CanvasGroup PauseCG;
    private GameObject LevelLoader; 
    // Start is called before the first frame update
    void Start()
    {
        LevelLoader = GameObject.Find("LevelLoader");
        PauseMBG = PauseM.GetComponent<Image>();
        PauseCG = PauseM.GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowP();
        }
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Resume();
        }

    }

    public void ShowP()
    {
        Time.timeScale = 0;
        PauseCG.alpha = 1;
        PauseCG.blocksRaycasts = true;
        
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseCG.alpha = 0;
        PauseCG.blocksRaycasts = false;
    }

    public void Save()
    {
        GameManager.instance.SaveState();
    }
    
    public void exitToMain()
    {
        GameManager.instance.SaveState();
        LevelLoader.GetComponent<LevelLoader>().LoadMainMenu();
        Debug.Log("oh no no no");
    }

}