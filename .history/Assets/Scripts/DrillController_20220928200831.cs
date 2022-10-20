using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hannah writing this - I work in pseudocode before actual code hehe
public class DrillControls : MonoBehaviour
{
    // NOTES FROM DESIGN:   It has full 360 degree control. Used to interact JUST with the "Resource Nodes" object. Will cause
    //                      the node to drop resources. Sprite for DrillArm can be rotated a full 360 degrees.

    // I have the extra turning on and off in case there's special animations where it changes in speed, it doesn't instantly
    // drill, etc. Not used for now.
    enum State {Idle, Drill, TurnOn, TurnOff };
    State currentState;
    float angle;

    void Start()
    {
        currentState = State.Idle;
        angle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
                // FIRST: FIGURE OUT ANGLE (maybe move each of these to a seperate method lol)
        Vector3 mousePos = Input.mousePosition;
        Vector2 playerPos = new Vector2(0,0);  // i prolly need an object for player first lol.

        float xDif = mousePos.x - playerPos.x;
        float yDif = mousePos.y - playerPos.y;
        angle = Mathf.Atan( (yDif / xDif) );

        // Angle is a result in radians, between [(pi/2),-(pi/2)]
        // Arctan only makes angles in the 1st and 4th quadrants! Fix hehe
        if ( xDif < 0 ) {
            angle += Mathf.Sign( yDif ) * ( Mathf.PI / 2 ); 
        }

        // Here I would set some value or call a method that alters the sprite's rotation?

            // NEXT: SET STATE GIVEN THE INPUT

        if ( Input.GetKeyDown( KeyCode.Mouse0 ) ) {
            currentState = State.Drill;
        }
        if ( Input.GetKeyUp( KeyCode.Mouse0 ) ) {
            currentState = State.Idle;
        }

        if ( currentState == State.Drill ) {
            // Resource nodes have NOT been implemented yet. I will come back to this later :)
            // BUT it would check for collisions with the resource object
        }
        // nothing for turnon and turnoff yet, but might change later
        
    }
}
