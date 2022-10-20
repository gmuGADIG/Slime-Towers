using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public int health;
    public int speed = 2;
    public Queue<Vector2> path;
    Vector3 target;
    Rigidbody2D rigidbody;
    float stunTimer = 0f;
    public float MinAvoidancDistance = 1f;
    private TowerManager towerManager;
    // Start is called before the first frame update
    void Start()
    {
        path = new Queue<Vector2>();
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        if (path.Count == 0) Pathfind();
        towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        } else
        {
            Move();
        }
        if (health <= 0) {
            Die();
        }
    }

    GameObject GetClosestTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        if (towers.Length == 0) return null;
        GameObject closest = towers[0];
        //Iterate through the list of towers to find the closest one
        for(int i = 1; i < towers.Length; i++)
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
        Vector3 lastQueued = this.transform.position;
        for(int i = 0; i < pathNodes.Length; i++)
        {

            int closesti = 0;
            for(int j = 0; j < pathNodes.Length; j++)
            {
                if(pathNodes[j] != null)
                {
                    if (pathNodes[closesti] == null) {
                        closesti = j;
                    } else if (
                        Vector3.Distance(lastQueued, pathNodes[j].transform.position) < Vector3.Distance(lastQueued, pathNodes[closesti].transform.position)
                        )
                    {
                        closesti = j;
                    }
                }
            }
            path.Enqueue(pathNodes[closesti].transform.position);
            lastQueued = pathNodes[closesti].transform.position;
            pathNodes[closesti] = null;
        }
        target = path.Dequeue();
    }
    void Move()
    {
        
        //Debug.Log(Vector2.Distance(target, this.transform.position));
        if(Vector2.Distance(target, this.transform.position) < 1)
        {
            if (path.Count == 0)
            {
                Die();
            }
            else
            {
                target = path.Dequeue();
            }
            
        }

        Vector2 DirectionToTargetVec = target - transform.position;
        DirectionToTargetVec.Normalize();
        rigidbody.velocity = DirectionToTargetVec;

        List<GameObject> closeTowers = GetTowersInRange(MinAvoidancDistance);
        for (int i = 0; i < closeTowers.Count; i++)
        {
            rigidbody.velocity += (Vector2)(this.transform.position - closeTowers[i].transform.position).normalized / Vector2.Distance(transform.position, closeTowers[i].transform.position);
             
             
        }
        rigidbody.velocity.Normalize();
        rigidbody.velocity *= speed;

    }

    Vector2 GetAvoidanceVector(GameObject toavoid)
    {
        Vector2 avoidancedirection = this.transform.position - toavoid.transform.position;
        avoidancedirection.Normalize();
        return avoidancedirection;
    }

    void TakeDamage(int DamageTaken)
    {
        health -= DamageTaken;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
