using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCollider : MonoBehaviour
{

    public string Scene;
    public Vector2 BackPos;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "O_Player"){
            if(Scene == "HUB"){
                TransferSceneScript.manager.BackToHub();
            }else{
                TransferSceneScript.manager.LoadScene(Scene,BackPos);
            }
            
        }
    }
}
