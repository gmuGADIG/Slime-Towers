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

        Move();
        if (health <= 0) {
            Die();
        }
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
            target = path.Dequeue();
            
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
