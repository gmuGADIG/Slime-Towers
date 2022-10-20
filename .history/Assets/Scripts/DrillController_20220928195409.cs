using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hannah writing this - I work in pseudocode before actual code hehe
public class DrillControls : MonoBehaviour
{
    // NOTES FROM DESIGN: It has full 360 degree control. Used for interaction with a resource node, and will drop 
    // ASSUMPTIONS: Used to interact JUST with the "Resource Nodes" object. Drill and it will interact and drop the resource.
    //              Sprite for DrillArm can be rotated a full 360 degrees it sounds? Clarify with design.


    // Maybe resource nodes should be same priority level?

    // I have the extra turning on and off in case there's special animations where it changes in speed, it doesn't instantly
    // drill, etc.
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

        if ( currentState = State.Drill ) {
            // Resource nodes have NOT been implemented yet. I will come back to this later :)
            // BUT it would check for collisions with the resource object
        }
        // nothing for turnon and turnoff yet, but might change later
        
        // is left mouse button being clicked?
            // set to drill
        // its NOT?
            // set to idle
        
            // IF DRILLING
        // check for collisions with resource object
            // call drill (object will have timer for between drops?)
            // really gonna need to make resource node to finish this part
    }
}
