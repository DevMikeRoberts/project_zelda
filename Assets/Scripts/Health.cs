using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHP = 0;
    public int maxHP = 100;
    public HPBar hpBar;
    // Start is called before the first frame update
    void Start(){
        currentHP = maxHP;   
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){ //test code to see if hpbar is working
            DamagePlayer(10);
        }
    }
    
    public void DamagePlayer(int damage){
        currentHP -= damage;
        hpBar.SetHealth(currentHP);
    }
}
