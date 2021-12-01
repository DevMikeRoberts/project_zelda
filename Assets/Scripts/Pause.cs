using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseM;
    public Image PauseMBG;
    // Start is called before the first frame update
    void Start()
    {
        PauseMBG = PauseM.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }

    public void Paused()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseMBG.color = Color.white;
            //show children
        }else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseMBG.color = Color.clear;
            //hide children
        }
    }
}
