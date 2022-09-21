using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
private Rigidbody2D rb2d;
private float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
     	rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	rb2d.velocity = new Vector2(0, 0);
    	if (Input.GetKey(KeyCode.E)){
    	
    	}
    	if (Input.GetKey(KeyCode.E)){
    	
    	}
        if (Input.GetKey(KeyCode.LeftArrow)){

        	rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow)){

        	rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
        	rb2d.velocity = new Vector2(rb2d.velocity.x, -speed);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
        	rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        }
    }
}
