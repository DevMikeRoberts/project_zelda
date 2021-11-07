using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();

        if(statusIndicator == null)
        {
            Debug.LogError("No status indicator referenced on Player");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    private void FixedUpdate() {

        float x = Input.GetAxisRaw("Horizontal"); //returns # for axis of movement
        float y = Input.GetAxisRaw("Vertical");

        //Reset moveDelta
        moveDelta = new Vector3(x,y,0);


        // Swap Sprite Direction, right or left
        if (moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0) {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Checks if we can move in y-axis by casting box; if box returns null, player can move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        if (hit.collider == null) {
            //Movement Control for player in y-axis
            transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        }
        //Checks if we can move in x-axis by casting box; if box returns null, player can move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(moveDelta.x, 0),Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        if (hit.collider == null) {
            //Movement Control for player in x-axis
            transform.Translate(moveDelta.x * Time.deltaTime,0,0);
        }

    }

    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        if(stats.curHealth <= 0)
        {
            //code to kill the player
        }

        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
}
