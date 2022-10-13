using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TowerAI : MonoBehaviour
{
    public float TargetSize;
    //change to element 0 of the targeted enemy list
    public GameObject TargetedEnemy;
    public List<GameObject> TargetedEnemyList;
    public float timeToHit = 5f;
    public float hitTimer;
    public float rotationSpeed = 3.0f;
    public bool hitEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        hitTimer = timeToHit;
        GetComponent<CircleCollider2D>().radius = TargetSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetedEnemy != null)
        {
            Vector3 targ = TargetedEnemy.transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            Quaternion target = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
        }


        hitTimer -= Time.deltaTime;
        if(hitTimer <= 0 )
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

            // Does the ray intersect any objects excluding the player layer
            if (hit.collider)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.grey, Mathf.Infinity);
                Debug.Log("Did Hit");
                hitEnemy = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.green);
                Debug.Log("Did not Hit");
                hitEnemy = false;
            }
            hitTimer = timeToHit;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (TargetedEnemy != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, TargetedEnemy.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log(collision.gameObject.name + " enters");
            
            if(TargetedEnemy == null)
            {
                TargetedEnemyList.Add(collision.gameObject);
                TargetedEnemy = TargetedEnemyList[0];
            }

            else if (TargetedEnemy != null)
            {

                TargetedEnemyList.Add(collision.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TargetedEnemyList.Remove(collision.gameObject);
            if (collision.gameObject == TargetedEnemy)
            {
                if (TargetedEnemyList.Count > 0)
                {
                    TargetedEnemy = TargetedEnemyList[0];
                }
                else
                {
                    TargetedEnemy = null;
                }
            }
        }
    }
}