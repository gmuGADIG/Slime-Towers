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
        collectEffect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            /*Inventory inventory = collision.gameObject.GetComponent<Inventory>();
            inventory.AddItem(material, 1); //TODO multi-item pickups?
            inventory.logStatus();

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collectEffect.Play();
            Destroy(gameObject,5);*/
            
        }
    }
}
