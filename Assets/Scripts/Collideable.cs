using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collideable : MonoBehaviour    {

    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    protected virtual void Update() {

        //Collision work
        boxCollider.OverlapCollider(filter,hits);

        for (int i = 0; i < 9; i++) {
            
            if (hits[i] == null) {
                continue;
            }

            OnCollide(hits[i]);

            hits[i] = null;
        }

    }

    protected virtual void OnCollide(Collider2D coll) {

        //Use inheritance to change behaviour on collision
        Debug.Log(coll.name);

    }


}
