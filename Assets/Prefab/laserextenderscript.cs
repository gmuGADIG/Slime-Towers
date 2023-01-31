using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserextenderscript : laserscript, ILaserTarget, IInteractable
{
    public bool moving;
    public PlayerMovement player;

    public float showTime;
    float interactTime;
    laserscript previous;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserObject, transform.position, transform.rotation);
        laser.SetActive(false);
    }

    public void OnLaserHit(laserscript source)
    {
        if (showTime <= 0)
        {
            previous = source;
        }
        if(previous == source)
		{
            showTime = .1f;
            laser.SetActive(true);
            generateLaser();
        }
    }

    protected override void Update()
    {
		if (moving)
		{
            interactTime += Time.deltaTime;
            transform.Rotate(Vector3.forward * -Input.GetAxis("Horizontal")*Time.deltaTime*45);
            if (Input.GetKeyDown(KeyCode.E) && interactTime >= .25f)
			{
                moving = false;
                player.enabled = true;
			}
		}

        if(showTime != -10)
		{
            showTime -= Time.deltaTime;
            if(showTime <= 0)
			{
                laser.SetActive(false);
			}
		}
    }

	string IInteractable.popup_text()
	{
        return "Rotate Laser";
	}

	void IInteractable.interact()
	{
        player = FindObjectOfType<PlayerMovement>();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.enabled = false;
        moving = true;
        interactTime = 0;
	}
}
