using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillHealth : MonoBehaviour
{
    //Script for the drill
    int health = 100;


    bool playerPresent = false;
    public float attackCooldown = 2.5f; //custom cooldowns for slime projectiles ?
    public float slimeSpeed = 1.5f;
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

        //Mouse position used as reference for where to aim AoE attacks
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        Debug.Log("MOUSE POSITION: " + direction.ToString());

        if (playerPresent){

            //play drill animation

            //player attack
            if (Input.GetButtonDown("Fire1") && Time.time > attackCooldown) {

                //get mouse location
                //calculate arc* (for now just a straight line)
                //instantiate cooldown

            }
        }
        else {
            //play drill stop animation
        }
    }
}
