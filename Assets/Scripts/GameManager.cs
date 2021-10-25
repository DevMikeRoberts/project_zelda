using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour    {

    public static GameManager instance;

    private void Awake() {

        if (GameManager.instance != null) {

            Destroy(gameObject);
            return;
        }
    
        instance = this;
        //SceneManager.sceneLoaded += SaveState;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    //Recources

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;


    //Logic
    public int gold;
    public int exp;

    //Save State Handling
    /*
    *INT preferedSkin
    *INT gold
    *INT exp
    *INT weapon
    *INT weaponLevel
    */

    public void SaveState() {

        string s = "";

        s += "0" + "|"; //to-do, implement character skin and id numbers
        s += gold.ToString() + "|";
        s += exp.ToString() + "|";
        s += "0" + "|"; //to-do, implement weapons and numbers
        s += "0";   //to-do, implement weapon levels and numbers


        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("SaveState");


    }

    public void LoadState(Scene scene, LoadSceneMode mode) {

        if (!PlayerPrefs.HasKey("SaveState")){
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //imput of form: "0|10|15|2|4" 

        //TO-DO: Change player skin

        gold = int.Parse(data[1]);
        exp = int.Parse(data[2]);

        //TO-DO: implement weapon

        //TO-DO: implement weapon level

        SceneManager.sceneLoaded -= LoadState;
        Debug.Log("LoadState");

    }



}
