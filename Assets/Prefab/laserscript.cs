using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour
{

    public GameObject laserObject;
    private GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserObject, transform.position, transform.rotation);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        generateLaser();
    }

    public void generateLaser()
    {
        RaycastHit2D cast = Physics2D.Raycast(transform.position, transform.rotation * Vector2.right);
        if (cast.collider != null)
        {
            if(cast.collider.GetComponent<ILaserTarget>() != null)
            {
                
                cast.collider.GetComponent<ILaserTarget>().OnLaserHit();
                
            }
            laser.GetComponent<laser>().SetLaser(transform.position, cast.point);
        } else
        {
            laser.GetComponent<laser>().SetLaser(transform.position, transform.rotation * (Vector2.right * 1000));
        }


    }


}
