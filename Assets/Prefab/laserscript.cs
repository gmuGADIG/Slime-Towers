using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour
{

    public GameObject laserObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(laserObject, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateLaser()
    {
        RaycastHit2D chekc = Physics2D.Raycast(transform.position, Vector2.right);
    }


}
