using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Collideable
{
    public AngelDialogue ad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollide(Collider2D coll) {

        if (coll.name == "Player") {
            ad.StartDialogue();
        }

    }

}
