using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUBmusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    void OnEnable()
    {
        audioSource.Play();
        Debug.Log("OnEnable - play hub theme again!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
