using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlocker : MonoBehaviour , ILaserTarget
{

    public float showTime;
	Collider2D col;
	SpriteRenderer rend;

	public void Start()
	{
		col = GetComponent<Collider2D>();
		rend = GetComponent<SpriteRenderer>();
	}

	void ILaserTarget.OnLaserHit(laserscript source)
	{
        showTime = .1f;
		col.enabled = false;
		rend.enabled = false;
	}

	public void Update()
	{
		if (showTime != -10)
		{
			showTime -= Time.deltaTime;
			if (showTime <= 0)
			{
				col.enabled = true;
				rend.enabled = true;
			}
		}
	}


}
