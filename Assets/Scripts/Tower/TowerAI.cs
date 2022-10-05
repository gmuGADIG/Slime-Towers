using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    public float TargetSize;
    public GameObject TargetedEnemy;

    // Start is called before the first frame update
    void Start()
    {
         GetComponent<CircleCollider2D>().radius = TargetSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetedEnemy != null)
        {
            Vector3 targ = TargetedEnemy.transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)* Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log(collision.gameObject.name + " enters");
            if (TargetedEnemy == null)
            {
                TargetedEnemy = collision.gameObject;

            }
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == TargetedEnemy)
        {
            Debug.Log(collision.gameObject.name + " exits");
            TargetedEnemy = null;
        }
    }
}
