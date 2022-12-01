using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TowerAI : MonoBehaviour
{
    [Header("Tower Settings")]
    public Tower TowerScrtipt;
    public float TargetSize;
    //change to element 0 of the targeted enemy list
    public GameObject TargetedEnemy;
    public List<GameObject> TargetedEnemyList;
    public bool hitEnemy = false;

    [Header("Art Sprites")]
    public Sprite SlimeDefault;
    public Sprite SlimeFire;
    public Sprite SlimeIce;
    public Sprite SlimeZap;
    public GameObject SlimeBaseRenderer;

    [Header("Basic Tower  Settings")]
    public bool defaultTower;
    public Sprite DefaultBase;
    public float timeToHit = 5f;
    public float hitTimer;
    public float rotationSpeed = 3.0f;
    
    [Header("Sniper Tower  Settings")]
    public bool sniperTower;
    public Sprite STBase;
    public float STTimeToHit = 5f;
    public float STHitTimer;
    public float STRotationSpeed = 3.0f;
    
    [Header("Aoe Tower  Settings")]
    public bool AOETower;
    public Sprite AOEBase;
    public Sprite AOESlimedefault, AOESlimeFire, AOESlimeIce, AOESlimeZap;
    public float AOETTimeToHit = 5f;
    public float AOETHitTimer;
    public float AOETRotationSpeed = 3.0f;

    [Header("Wall Tower  Settings")]
    public bool wallTower;
    public Sprite wallBase;

    // Start is called before the first frame update
    void Start()
    {
        TowerScrtipt = SlimeBaseRenderer.GetComponent<Tower>();
            //FindObjectOfType<Tower>();
        hitTimer = timeToHit;
        GetComponent<CircleCollider2D>().radius = TargetSize;

        if (defaultTower)
        {
            GetComponent<SpriteRenderer>().sprite = DefaultBase;
        }
        else if (sniperTower)
        {
            GetComponent<SpriteRenderer>().sprite = STBase;
        }
        else if (AOETower)
        {
            GetComponent<SpriteRenderer>().sprite = AOEBase;
        }
        else if (wallTower)
        {
            GetComponent<SpriteRenderer>().sprite = wallBase;
        }
        slimeSpriteUpdate();
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    private void Update()
    {
        if (TowerScrtipt.slime == Slime_Type.Default && TargetedEnemy != null)
        {
            slimeDefault ();
        }
        else if (TowerScrtipt.slime == Slime_Type.Fire && TargetedEnemy != null)
        {
            slimeFire();
        }
        else if (TowerScrtipt.slime == Slime_Type.Ice && TargetedEnemy != null)
        {
            slimeIce();
        }
        else if (TowerScrtipt.slime == Slime_Type.Zap && TargetedEnemy != null)
        {
            slimeZap();
        }
    }

    public void slimeSpriteUpdate()
    {
        if (TowerScrtipt.slime == Slime_Type.Default)
        {
            if (AOETower)
            {
                SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = AOESlimedefault;
            }
            SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = SlimeDefault;
        }
        else if (TowerScrtipt.slime == Slime_Type.Fire)
        {
            if (AOETower)
            {
                SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = AOESlimeFire;
            }
            SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = SlimeFire;
        }
        else if (TowerScrtipt.slime == Slime_Type.Ice)
        {
            if (AOETower)
            {
                SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = AOESlimeIce;
            }
            SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = SlimeIce;
        }
        else if (TowerScrtipt.slime == Slime_Type.Zap)
        {
            if (AOETower)
            {
                SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = AOESlimeZap;
            }
            SlimeBaseRenderer.GetComponent<SpriteRenderer>().sprite = SlimeZap;
        }
    }

    void slimeDefault()
    {
        if (AOETower)
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

        if (sniperTower)
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

        if (defaultTower)
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
            if (hitTimer <= 0 && TargetedEnemy != null)
            {
                hitTimer = timeToHit;
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
    }

    void slimeFire() 
    {
        if (AOETower)
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

        else if (sniperTower)
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

        else if (defaultTower)
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
            if (hitTimer <= 0 && TargetedEnemy != null)
            {
                hitTimer = timeToHit;
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
    }

    void slimeIce()
    {
        if (AOETower)
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

        else if (sniperTower)
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

        else if (defaultTower)
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
            if (hitTimer <= 0 && TargetedEnemy != null)
            {
                hitTimer = timeToHit;
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
    }

    void slimeZap()
    {
        if (AOETower)
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

        else if (sniperTower)
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

        else if (defaultTower)
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
            if (hitTimer <= 0 && TargetedEnemy != null)
            {
                hitTimer = timeToHit;
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