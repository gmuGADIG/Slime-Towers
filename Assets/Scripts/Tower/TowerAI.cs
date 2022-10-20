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
        if(hitTimer <= 0 && TargetedEnemy != null)
        {
            hitTimer = timeToHit;
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), new ContactFilter2D(), hits);
            foreach(RaycastHit2D hit in hits)
            // Does the ray intersect any objects excluding the player layer
            if (hit.collider != null && hit.collider.tag == "enemy")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1000,  Color.yellow, .5f);
                Debug.Log("Did Hit");
                hitEnemy = true;
                hit.collider.GetComponent<EnemyBehavior>().health -= 5;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1000, Color.red,.1f);
                Debug.Log("Did not Hit");
                hitEnemy = false;
            }            
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