using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEAnim : MonoBehaviour
{

    public float AnimTime;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (t < AnimTime)
		{
            transform.localScale = Vector3.one * (t / AnimTime);
            t += Time.deltaTime;
		}
		else
		{
            Destroy(gameObject);
		}
    }
}
