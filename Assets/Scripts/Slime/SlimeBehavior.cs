using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
    // These variables are public so that the slime movement behavior
    // can be freely adjusted for each slime
    public int speed = 2;
    public float xLimit = 5.0f;
    public float yLimit = 5.0f;
    public float lowerTimeLimit = 1.0f;
    public float upperTimeLimit = 5.0f;

    private Rigidbody2D rigidbody;
    private Vector2 direction;
    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        startingPosition = gameObject.transform.position;
        StartCoroutine(DetermineDirection());
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = direction * speed;
        leash();
    }

    // leash is used to keep the slime within a certain range of its
    // starting position. This range is controlled by the 
    // xLimit and yLimit variables.
    private void leash()
    {
        if (transform.position.x > (startingPosition.x + xLimit))
        {
            transform.position = new Vector2((startingPosition.x + xLimit), transform.position.y);
        }

        if (transform.position.x < (startingPosition.x - xLimit))
        {
            transform.position = new Vector2((startingPosition.x - xLimit), transform.position.y);
        }

        if (transform.position.y > (startingPosition.y + yLimit))
        {
            transform.position = new Vector2(transform.position.x, (startingPosition.y + yLimit));
        }

        if (transform.position.y < (startingPosition.y - yLimit))
        {
            transform.position = new Vector2(transform.position.x, (startingPosition.y - yLimit));
        }
    }

    // This determines the direction the slime moves in
    // The rate at which the slime changes direction is decided
    // by the lowerTimeLimit and upperTimeLimit variables
    IEnumerator DetermineDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(lowerTimeLimit, upperTimeLimit));
            direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        }
    }
}
