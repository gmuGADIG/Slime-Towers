using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour
{

    public GameObject laserObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(laserObject, transform.position, new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
