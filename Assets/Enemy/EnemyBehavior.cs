using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health;
    public int speed;
    public Vector2 DirectionToTargetVec;
    public GameObject Target;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Finish"); 
    }

    // Update is called once per frame
    void Update()
    {
        DirectionToTargetVec = Target.transform.position - this.transform.position;
        DirectionToTargetVec.Normalize();
        this.gameObject.GetComponent<Rigidbody2D>().velocity = DirectionToTargetVec * speed;
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }
    void TakeDamage(int DamageTaken)
    {
        health -= DamageTaken;
    }
}
