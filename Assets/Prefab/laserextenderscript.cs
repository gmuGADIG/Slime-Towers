using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserextenderscript : laserscript, ILaserTarget
{

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(laserObject, transform.position, transform.rotation);
    }

    public void OnLaserHit()
    {
        generateLaser();
    }

    protected override void Update()
    {
        
    }

}
