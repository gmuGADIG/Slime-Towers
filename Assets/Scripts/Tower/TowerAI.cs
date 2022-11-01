using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TowerAI : MonoBehaviour
{
    public Tower TowerScrtipt;
    public float TargetSize;
    //change to element 0 of the targeted enemy list
    public GameObject TargetedEnemy;
    public List<GameObject> TargetedEnemyList;
    public bool hitEnemy = false;

    [Header("Basic Tower  Settings")]
    public float timeToHit = 5f;
    public float hitTimer;
    public float rotationSpeed = 3.0f;
    
    [Header("Sniper Tower  Settings")]
    public float STTimeToHit = 5f;
    public float STHitTimer;
    public float STRotationSpeed = 3.0f;
    
    [Header("Aoe Tower  Settings")]
    public float AOETTimeToHit = 5f;
    public float AOETHitTimer;
    public float AOETRotationSpeed = 3.0f;

    public bool defaultTower;
    public bool sniperTower;
    public bool AOETower;
    public bool wallTower;

    // Start is called before the first frame update
    void Start()
    {
        TowerScrtipt = FindObjectOfType<Tower>();
        hitTimer = timeToHit;
        GetComponent<CircleCollider2D>().radius = TargetSize;
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        if (defaultTower && TowerScrtipt.slime != Slime_Type.None && TargetedEnemy != null)
        {
            Tbasic();
        }
        else if (sniperTower && TowerScrtipt.slime != Slime_Type.None && TargetedEnemy != null)
        {
            TSnipe();
        }
        else if (AOETower && TowerScrtipt.slime != Slime_Type.None && TargetedEnemy != null)
        {
            TAOE();
        }
        else
        {
        }
    }

    void TAOE()
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
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * AOETRotationSpeed);
        }


        AOETHitTimer -= Time.deltaTime;
        if (AOETHitTimer <= 0 && TargetedEnemy != null)
        {
            AOETHitTimer = AOETTimeToHit;
            foreach (GameObject enemy in TargetedEnemyList)
            {
                enemy.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    void TSnipe()
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
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * STRotationSpeed);
        }


        STHitTimer -= Time.deltaTime;
        if (STHitTimer <= 0 && TargetedEnemy != null)
        {
            STHitTimer = STTimeToHit;
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), new ContactFilter2D(), hits);
            foreach (RaycastHit2D hit in hits)
                // Does the ray intersect any objects excluding the player layer
                if (hit.collider != null && hit.collider.tag == "enemy")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1000, Color.yellow, .5f);
                    Debug.Log("Did Hit");
                    hitEnemy = true;
                    hit.collider.GetComponent<EnemyBehavior>().health -= 5;
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1000, Color.red, .1f);
                    Debug.Log("Did not Hit");
                    hitEnemy = false;
                }
        }
    }

    void Tbasic()
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
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow, Mathf.Infinity);
                Debug.Log("Did Hit");
                hitEnemy = true;
                hit.collider.gameObject.SetActive(false);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.red);
                Debug.Log("Did not Hit");
                hitEnemy = false;
            }
            if (hit.collider.gameObject.tag == "enemy") 
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green); print("Hit"); 
            }
            hitTimer = timeToHit + 100;
        }
    }
    
    /*void OnDrawGizmosSelected()
    {
        if (TargetedEnemy != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, TargetedEnemy.transform.position);
        }
    }*/

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