using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehavior : MonoBehaviour
{

    public int health;
    public int speed = 2;
    //public Queue<Vector2> path;
    public GameObject nextNode;
    Rigidbody2D rigidbody;
    public float stunTimer = 0f;
    public float fireTimer = 0f;
    public float fireTickRate = 0.5f;
    private float fireTickTimer = 0f;
    public int fireDamage = 1;

    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    public float MinAvoidancDistance = 1f;
    public TowerManager towerManager;
    public UnityEvent<GameObject> onDeath;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    private void Awake()
    {
        towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

        Pathfind();
        //GetComponent<Animation>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (nextNode == null)
        {
            Pathfind();
        }
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
        else
        {
            Move();
        }
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
            if (fireTickTimer > 0)
            {
                fireTickTimer -= Time.deltaTime;
            }
            else
            {
                fireTickTimer = fireTickRate;
                TakeDamage(fireDamage);
            }

        }
        if (health <= 0)
        {
            Die();
        }
    }

    GameObject GetClosestTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        if (towers.Length == 0) return null;
        GameObject closest = towers[0];
        //Iterate through the list of towers to find the closest one
        for (int i = 1; i < towers.Length; i++)
        {
            if (Vector3.Distance(towers[i].transform.position, this.transform.position) < Vector3.Distance(closest.transform.position, this.transform.position))
            {
                closest = towers[i];
            }
        }

        Debug.Log(Vector3.Distance(closest.transform.position, this.transform.position));
        return closest;
    }

    List<GameObject> GetTowersInRange(float range)
    {
        List<GameObject> towersInRange = new List<GameObject>();
        List<GameObject> towers = towerManager.activeTowers;
        for (int i = 0; i < towers.Count; i++)
        {
            if (Vector3.Distance(towers[i].transform.position, this.transform.position) < range)
                towersInRange.Add(towers[i]);
        }
        return towersInRange;



    }
    void Pathfind()
    {
        GameObject[] pathNodes = GameObject.FindGameObjectsWithTag("Finish");
        if (pathNodes.Length == 0) return;
        GameObject closest = pathNodes[0];
        //Iterate through the list of towers to find the closest one
        for (int i = 1; i < pathNodes.Length; i++)
        {
            if (Vector3.Distance(pathNodes[i].transform.position, this.transform.position) < Vector3.Distance(closest.transform.position, this.transform.position))
            {
                closest = pathNodes[i];
            }
        }
        nextNode = closest;
    }
    void Move()
    {

        //Debug.Log(Vector2.Distance(target, this.transform.position));
        if (Vector2.Distance(nextNode.transform.position, this.transform.position) < 1)
        {
            if (nextNode.GetComponent<PathfindingNode>().endPoint)
            {
                //Die();
                
            }
            else
            {
                nextNode = nextNode.GetComponent<PathfindingNode>().nextNode;
            }

        }

        Vector2 DirectionToTargetVec = nextNode.transform.position - transform.position;
        //DirectionToTargetVec.Normalize();
        rigidbody.velocity = DirectionToTargetVec.normalized;
        //Debug.DrawRay(this.transform.position, DirectionToTargetVec, Color.red);
        List<GameObject> closeTowers = GetTowersInRange(MinAvoidancDistance);
        for (int i = 0; i < closeTowers.Count; i++)
        {

            Vector2 direction = (this.transform.position - closeTowers[i].transform.position);
            rigidbody.velocity += direction.normalized * (direction.sqrMagnitude * (1 / MinAvoidancDistance));

            Debug.DrawLine(this.transform.position, closeTowers[i].transform.position, Color.green, 0.1f);
        }
        rigidbody.velocity.Normalize();
        rigidbody.velocity *= speed;
        float lookAngle = transform.rotation.eulerAngles.z - ((Mathf.Rad2Deg * Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x) - 90));
        if (Mathf.Abs(lookAngle) > 5)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, (Mathf.Rad2Deg * Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x) - 90), 360 * Time.deltaTime)));
        }



    }

    Vector2 GetAvoidanceVector(GameObject toavoid)
    {
        Vector2 avoidancedirection = this.transform.position - toavoid.transform.position;
        avoidancedirection.Normalize();
        return avoidancedirection;
    }

    public void TakeDamage(int DamageTaken)
    {
        health -= DamageTaken;
    }
    public void Burn(int FireDamage, int FireDuration, int FireTickRate)
    {
        fireDamage = FireDamage;
        fireTimer = FireDuration;
        fireTickRate = FireTickRate;
    }

    public void Stun(float StunDuration)
    {
        stunTimer = StunDuration;
    }
    void Die()
    {
        onDeath.Invoke(gameObject);
        Destroy(this.gameObject);
    }

    public void Attack(DrillHealth drill)
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attackTimer = attackCooldown;
            //how do i animate??
            //Also drill health is set package-protected
        }
    }
}
