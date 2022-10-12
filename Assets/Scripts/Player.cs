using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//defunct
public class Player : MonoBehaviour
{
    private CircleCollider2D interact;
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



        //player interact
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


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Drill")) {
            //highlight drill
            Debug.Log("Drill in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag.Equals("Drill")){
            //highlight drill
            Debug.Log("Drill out of range");
        }
    }

}
