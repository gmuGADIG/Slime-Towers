using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health;
    public int speed;
    public Queue<Vector2> path;
    Vector3 target;
    Rigidbody2D rigidbody;
    float stunTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        path = new Queue<Vector2>();
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        if (path.Count == 0) Pathfind();

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
            //if(Vector3.Distance(towers[i].]))
        }


        return null;
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
        
        Debug.Log(Vector2.Distance(target, this.transform.position));
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
        rigidbody.velocity = DirectionToTargetVec * speed;


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
