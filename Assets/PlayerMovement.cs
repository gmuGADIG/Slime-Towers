using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 movement;
    float inputX;
    float inputY;
    
    public float speed = 5f;
    public float sprintSpeed = 7.5f;
    public float accel = 2f;

    bool isSlow = false;
    public Rigidbody2D rigidBody;

    LayerMask groundLayer;



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
            transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * (speed + sprintSpeed));
        }
        else {
            transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Wall"))
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
}
