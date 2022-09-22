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

        //If player inputs WASD or the arrow keys, it'll move the player object
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

        	rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){

        	rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
        	rb2d.velocity = new Vector2(rb2d.velocity.x, -speed);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
        	rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        }
    }
}
