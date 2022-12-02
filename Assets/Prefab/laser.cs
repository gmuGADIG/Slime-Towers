using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    LineRenderer laserLine;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetPosition(0, transform.position);
    }


    public void SetLaser(Vector2 orgin, Vector2 target)
    {
        laserLine.SetPosition(0, orgin);
        laserLine.SetPosition(1, target);
    }
}
