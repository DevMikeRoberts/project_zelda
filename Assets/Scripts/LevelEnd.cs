using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    GameObject EndScreenM;
    CanvasGroup EndScreenCG;
    float stopwatch;
    Text stopwatchTxt;
    Image endScreenBG;
    private Player player;
    Text dmgtotal;
    Text EKtotal;
    Text scoreTxt;
    bool flag = true;


    void Start()
    {
        EndScreenM = GameObject.Find("EndScreen");
        EndScreenCG = EndScreenM.GetComponent<CanvasGroup>();
        endScreenBG = EndScreenM.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == true)
        {
            stopwatch += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && flag == false)
        {
            hide();
            flag = true;
            player.endLevel = 1;
        }
    }
    public void CreateEM()
    {
        flag = false; //stop stopwatch
        show();
        player = GameObject.Find("Player").GetComponent<Player>();
        int score = 0;

        //Time
        stopwatchTxt = GameObject.Find("stopwatch").GetComponent<Text>();
        int currentTime = (int)Mathf.Round(stopwatch);
        stopwatchTxt.text = currentTime.ToString();
        if (currentTime < 60) { score += 600; }
        else if (currentTime > 60 && currentTime < 300) { score += 600 - (currentTime - 60) * 2; }
        else if (currentTime > 300) { score += 120; }

        //Damage taken
        dmgtotal = GameObject.Find("dmgtaken").GetComponent<Text>();
        dmgtotal.text = player.dmgtaken.ToString();
        score += 300 - player.dmgtaken;

        //Enemies Killed
        EKtotal = GameObject.Find("EKtotal").GetComponent<Text>();
        EKtotal.text = player.enemiesKilled.ToString();
        score += player.enemiesKilled * 20;

        //score
        scoreTxt = GameObject.Find("score").GetComponent<Text>();
        scoreTxt.text = score.ToString();

    }
    public void show()
    {
        EndScreenCG.alpha = 1;
        EndScreenCG.blocksRaycasts = true;
    }
    public void hide()
    {
        EndScreenCG.alpha = 0;
        EndScreenCG.blocksRaycasts = false;
    }
}