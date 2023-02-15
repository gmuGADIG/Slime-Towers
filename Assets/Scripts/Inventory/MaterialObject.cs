using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MaterialType = SlimeTowers.MaterialType;

public class MaterialObject : MonoBehaviour {

    public ParticleSystem collectEffect;
    public AudioClip collectSound;
    public AudioSource audioSource;
    [SerializeField]
    private MaterialType material;

    // Start is called before the first frame update
    void Start()
    {
        collectEffect = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().canInteract) {
                Inventory inventory = Inventory.inventory;
                inventory.AddItem(material, 5); //TODO multi-item pickups?
                inventory.logStatus();

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                collectEffect.Play();
                audioSource.PlayOneShot(collectSound,1.0f);
                Destroy(gameObject,5);
            }
        }
    }
}
