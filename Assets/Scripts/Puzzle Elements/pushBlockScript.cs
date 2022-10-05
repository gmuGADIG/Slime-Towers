using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBlockScript : MonoBehaviour
{
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 dir = collision.transform.position - transform.position;
            Vector2 vel = Vector2.zero;
            if(Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
            {
                vel = new Vector2(0,collision.gameObject.GetComponent<PlayerMovement>().velocity.y);
            }
            else
            {
                vel = new Vector2(collision.gameObject.GetComponent<PlayerMovement>().velocity.x,0);
            }
            transform.Translate(vel);
        }
        
        //Debug.Log("Test");
        //transform.Translate(Vector2.up);
    }
}
