using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player movement variables
    Vector2 movement;
    float inputX, inputY;
    
    public float speed = 5f;
    public float sprintSpeed = 7.5f;
    public float accel = 2f;

    public Vector2 velocity;

    bool isSlow = false;
    public Rigidbody2D rigidBody;
    
    LayerMask groundLayer;


    //player interaction



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (Input.GetKey("left shift"))
        {
            velocity = new Vector2(inputX, inputY) * Time.deltaTime * (speed + sprintSpeed);
        }
        else {
            velocity = new Vector2(inputX, inputY) * Time.deltaTime * speed;
        }

        transform.Translate(velocity);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Wall"))
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    /*
     * pseudocode for tile hop method:
     * if a gap is a certain distance and the player is moving in the direction of the gap:
     * there will be a short pause, then do the jump
     */

    private void OnTriggerStay(Collider other)
    {
        if(other){
            
        }
    }

}
