using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 40;

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public EnemyStats stats = new EnemyStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    //[SerializeField]
    //GameObject objectToDestroy;

    public Transform target;
    //public Transform target2 = null;

    //public Camera camera;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemygfx;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    Player player;
    bool playerInRange;
    float timer;

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    [SerializeField]
    GameObject objectToDestroy;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
       // camera = GameObject.FindObjectWithTag("camera");

        InvokeRepeating("UpdatePath", 0f, .5f);

        stats.Init();
        if(statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
        
        
;    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemygfx.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (force.x <= -0.01f)
        {
            enemygfx.localScale = new Vector3(-1f, 1f, 1f);
        }

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (player.currentHP > 0)
        {
            player.DamagePlayer(attackDamage);
        }
    }

    public void DamageEnemy(int damage)
    {

        stats.curHealth -= damage;
        //hpBar.SetHealth(currentHP);
        if (stats.curHealth <= 0)
        {
            Destroy(objectToDestroy);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }
}
