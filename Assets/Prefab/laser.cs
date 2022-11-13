using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;

    LineRenderer laserLine;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetPosition(0, transform.position);
    }


    // Update is called once per frame
    void Update()
    {

        RaycastHit2D shootDaLaser = Physics2D.Raycast(transform.position, Vector2.right);


        if (shootDaLaser)
        {
            laserLine.SetPosition(1, shootDaLaser.point);
        }

        else
        {
            laserLine.SetPosition(1, transform.position + Vector3.right * 100);
        }

        
    }
}
