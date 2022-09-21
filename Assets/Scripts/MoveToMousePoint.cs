using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMousePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Input.mousePosition;
        point.z = 10;
        point = Camera.main.ScreenToWorldPoint(point);
        transform.position = point;
    }
}
