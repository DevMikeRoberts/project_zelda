using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpBar;
    public Health health;
    // Start is called before the first frame update
    void Start(){
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = health.maxHP;
        hpBar.value = health.maxHP; 
    }

    public void SetHealth(int hp){
        hpBar.value = hp;
    }
}
