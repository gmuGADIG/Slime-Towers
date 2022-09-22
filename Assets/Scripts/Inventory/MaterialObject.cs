using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MaterialType = SlimeTowers.MaterialType;

public class MaterialObject : MonoBehaviour
{

    public ParticleSystem collectEffect;
    public AudioClip collectSound;
    [SerializeField]
    private MaterialType material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Inventory>().AddItem(material, 1); //TODO multi-item pickups?
            collectEffect.Play();
            Destroy(gameObject,5);
        }
    }
}
