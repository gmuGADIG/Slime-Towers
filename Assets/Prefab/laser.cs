using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    
    /*
    

    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

    if (hit.collider != null)
        {
        
        }




    send out a raycast

    if the raycast hits:
        set a new point at the raycast's result
    if it's a crystal:
        then redirect, send out a new raycast in a direction
    elif not:
        don't do that lol
    do that same thing again
     */

    // Update is called once per frame
    void Update()
    {
        
    }
}
