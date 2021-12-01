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
    private Player player;
    public Text dmgtotal;
    public float time = 60f;

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
        //if (Input.GetKeyDown(KeyCode.Space)){ Time.timeScale = 1;}
    }
    public void CreateEM()
    {
        endScreenBG.color = Color.white;
        foreach (Text temp in endScreen.GetComponentsInChildren<Text>())
        {
            temp.color = Color.white;
        }
        stopwatchTxt.text = Mathf.Round(stopwatch).ToString();
        player = GameObject.Find("Player").GetComponent<Player>();
        dmgtotal.text = player.dmgtaken.ToString();
        int score = 0;
        if (int.Parse(stopwatchTxt.text) < 60) { score += 600; }
        else if (int.Parse(stopwatchTxt.text) > 60 && int.Parse(stopwatchTxt.text) < 300) { score += 600 - (int.Parse(stopwatchTxt.text) - 60) * 2; }
        else if (int.Parse(stopwatchTxt.text) > 300) { score += 120; }

        score += 300 - player.dmgtaken;

        //score += number of enemies killed * 10;

        //wait on end level screen
        //Time.timeScale = 0;
        //StartCoroutine(Wait(time));
        //StartCoroutine(WaitForKeyDown(keycode.space));

        //after resuming: 
        endScreenBG.color = Color.clear;
        foreach (Text temp in endScreen.GetComponentsInChildren<Text>())
        {
            temp.color = Color.white;
        }
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    IEnumerator WaitForKeyDown(KeyCode keycode) //wait until input
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keycode));
    }
}