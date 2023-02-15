using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Vector3 start;
    public EnemyBehavior end;
    public float speed;
    float AnimTime;
    float t;
    Vector3 vel;


    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        AnimTime = Vector3.Distance(start, end.transform.position)/speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(end == null)
		{
            Destroy(gameObject);
		}
		else
		{
            if (Vector3.Distance(transform.position, end.transform.position) > .25f)
            {
                Vector3 diff = end.transform.position - transform.position;
                float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                transform.position = transform.position + (diff.normalized * speed * Time.deltaTime);
                t += Time.deltaTime;
            }
            else
            {
                end.health -= 5;
                Destroy(gameObject);
            }
        }


    }
}
