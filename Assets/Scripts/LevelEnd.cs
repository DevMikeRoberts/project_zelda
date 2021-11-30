using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public float stopwatch;
    public Text stopwatchTxt;
    public GameObject endScreen;
    public Image endScreenBG;

    // Start is called before the first frame update
    void Start()
    {
        stopwatchTxt.text = stopwatch.ToString();
        endScreenBG = endScreen.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        stopwatch += Time.deltaTime;
        stopwatchTxt.text = Mathf.Round(stopwatch).ToString();
        //if (Input.GetKeyDown(KeyCode.Space)){ Time.timeScale = 1;}
    }
    public void CreateEM() //display and then go to coroutine
    {
        endScreenBG.color = Color.white;
        foreach (Text temp in endScreen.GetComponentsInChildren<Text>())
        {
            temp.color = Color.white;
        }
        ///update values on EM after confirming score w team
        //wait on end level screen
        //Time.timeScale = 0;
        //StartCoroutine(Rest());

        //after resuming: 
        endScreenBG.color = Color.clear;
        foreach (Text temp in endScreen.GetComponentsInChildren<Text>())
        {
            temp.color = Color.white;
        }
    }
    IEnumerator Rest() //wait until input
    {
        yield return waitFor();
    }
    private IEnumerator waitFor()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetKeyDown("space"))
            {
                done = true;
            }
            yield return null;
        }
    }
}