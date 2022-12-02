using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferSceneScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Hub;
    public Vector2 BackPos;
    public GameObject CurScene;
    public Scene loadedScene;
    public static TransferSceneScript manager;

    public void Awake(){
        if(manager == null){
            manager = this;
        }
    }

    public void LoadScene(string Scene, Vector2 Pos){
        BackPos = Pos;
        SceneManager.LoadScene(Scene,LoadSceneMode.Additive);
        loadedScene = SceneManager.GetSceneByName(Scene);
        Hub.SetActive(false);
        Invoke("MovePlayer",.1f);
    }

    public void MovePlayer(){
        CurScene = GameObject.Find("SceneObject");
        Player.transform.position = CurScene.transform.position;
    }

    public void BackToHub(){
        SceneManager.UnloadSceneAsync(loadedScene);
        Player.transform.position = BackPos;
        Hub.SetActive(true);
    }

}
