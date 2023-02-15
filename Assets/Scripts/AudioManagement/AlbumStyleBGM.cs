using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumStyleBGM : MonoBehaviour
{
    public List<AudioClip> CurrentCaveThemes;
    public List<AudioClip> CurrentCaveAmbience;
    AudioSource audioSource;
    int currentBGM;
    int targetBGM;
    int currentAMB;
    int targetAMB;
    bool bgmShouldPlayNext;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bgmShouldPlayNext = true;
        //set default values
        targetBGM = (int)Random.Range(0.0f, CurrentCaveThemes.Count);
        currentBGM = (int)Random.Range(0.0f, CurrentCaveThemes.Count);
        targetAMB = (int)Random.Range(0.0f, CurrentCaveAmbience.Count);
        currentAMB = (int)Random.Range(0.0f, CurrentCaveAmbience.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //choose new song if nothing's playing
        if (audioSource.isPlaying == false)
        {
            if (bgmShouldPlayNext == true) { 
                //prevent same song from playing twice in a row
                while (targetBGM == currentBGM) { 
                    targetBGM = (int)Random.Range(0.0f, CurrentCaveThemes.Count);
                }
                audioSource.PlayOneShot(CurrentCaveThemes[targetBGM]);
                currentBGM = targetBGM;
                bgmShouldPlayNext = false;
            }
            else
            {
                //prevent same song from playing twice in a row
                while (targetAMB == currentAMB)
                {
                    targetAMB = (int)Random.Range(0.0f, CurrentCaveAmbience.Count);
                }
                audioSource.PlayOneShot(CurrentCaveAmbience[targetAMB]);
                currentAMB= targetAMB;
                bgmShouldPlayNext = true;
            }
        }
        //just for debugging purposes -- instantly ends current song to roll a new one
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // audioSource.Stop();
        }

    }
}
