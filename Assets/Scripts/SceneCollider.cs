using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCollider : MonoBehaviour
{
    public GameObject gameManager;
    public string Scene;
    public Vector2 BackPos;
    public GameObject musicToKill;
    public GameObject HUBmusic;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "O_Player"){
            if(Scene == "HUB"){
                
                musicToKill = GameObject.FindGameObjectWithTag("AlbumBGM");
                Destroy(musicToKill.gameObject);
                Debug.Log("OnColEnter2d - Going To Hub, Killing Album");
                TransferSceneScript.manager.BackToHub();

            }
            else{
                HUBmusic = GameObject.Find("HUBbgm");
                HUBmusic.GetComponent<AudioSource>().Stop();
                TransferSceneScript.manager.LoadScene(Scene,BackPos);
                Debug.Log("OnColEnter2s - Leaving Hub, Stopping BGM");
            }
            
        }
    }
}
