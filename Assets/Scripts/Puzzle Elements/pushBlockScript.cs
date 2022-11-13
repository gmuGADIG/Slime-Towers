using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBlockScript : MonoBehaviour
{
    Vector2 movement;
    bool isPush = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isPush = false;
    }

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("got hiut");
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("this is really happening");
    //        Vector2 dir = collision.transform.position - transform.position;
    //        Vector2 vel = Vector2.zero;
    //        if(Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
    //        {
    //            vel = new Vector2(0,collision.gameObject.GetComponent<PlayerMovement>().rigidBody.velocity.y);
    //        }
    //        else
    //        {
    //            vel = new Vector2(collision.gameObject.GetComponent<PlayerMovement>().rigidBody.velocity.x,0);
    //        }
    //        gameObject.GetComponent<Rigidbody2D>().AddForce(vel);
    //    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isPush = true;
        //Debug.Log("Test");
        //transform.Translate(Vector2.up);
    }
}
