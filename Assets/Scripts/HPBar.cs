using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpBar;
    public Player player;

    // Start is called before the first frame update
    void Start()    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = player.maxHP;
        hpBar.value = player.maxHP; 
    }

    public void SetHealth(int hp)   { 
        hpBar.value = hp;
    }
}
