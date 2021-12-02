using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngelDialogue : Collideable
{
    [Header("inputs")]
    public string dialogue;
    [SerializeField] private float typingSpeed = 0.3f;
    [SerializeField] public TextMeshProUGUI message;
    public SpriteRenderer speechBubble;
    private int start = 0;
    private bool firstSpoken = true;

    protected override void OnCollide(Collider2D coll) {
        Debug.Log("Collided");
        Debug.Log(coll.name);
        if (coll.name == "Player") {
            if (start == 0){start = 1;}
            StartDialogue();
            if(start == 1){firstSpoken = false;}
            start = 2;
        }
    }

    public void StartDialogue(){
        if (start ==1){
            speechBubble.GetComponent<SpriteRenderer>().enabled = true;
            if(firstSpoken) {StartCoroutine(TypeMessage());}
            else{message.enabled = true;}
            StartCoroutine(waiter());
        }
    }

    private IEnumerator TypeMessage(){
        foreach ( char letter in dialogue.ToCharArray()){
            message.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private IEnumerator waiter(){
        yield return new WaitForSeconds(3);
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
        message.enabled = false;
        start = 0;
    }
}
