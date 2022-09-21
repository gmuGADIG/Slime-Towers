using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float inputX;
    float inputY;
    float speed = 5f;
    Vector2 movement;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * speed);
    }
}
