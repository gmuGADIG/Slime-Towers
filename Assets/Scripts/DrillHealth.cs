using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillHealth : MonoBehaviour {

    public ManagerScript manager;

    //Script for the drill
    int health = 100;
    bool playerPresent = false;

    public GameObject player;
    public Camera drillCamera;
    public Camera playerCamera;
    public GameObject slimeProjectile;
    public Transform slimeProjectileTransform;
    public float attackCooldown = 2.5f; //custom cooldowns for slime projectiles ?
    public float slimeSpeed = 1.5f;

    public Wave wave;


    // Start is called before the first frame update
    void Start(){
        playerCamera = Camera.main;
        wave.onWaveComplete.AddListener(playerExit);
    }

    // Update is called once per frame
    void Update(){

        //Mouse position used as reference for where to aim AoE attacks
        Vector3 mousePos = Input.mousePosition;
        mousePos = drillCamera.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //Debug.Log("MOUSE POSITION: " + direction.ToString());

        if (playerPresent){

            //play drill animation

            //player attack
            /*if (Input.GetButtonDown("Fire1") && Time.time > attackCooldown){

                Debug.Log("Firing");
                Instantiate(slimeProjectile, slimeProjectileTransform.position, Quaternion.identity);

                //get mouse location
                //calculate arc* (for now just a straight line)
                //instantiate cooldown 
            }
            else if (Input.GetButtonDown("Fire1") && Time.time < attackCooldown) {
                Debug.Log("recharging... Can't fire");
            }*/

            //playerExit
            /*if (Input.GetKeyDown(KeyCode.E) && (manager.getGameState() != GameState.ATTACK) ) {
                playerExit();
            }
            //player feedback(attack phase still underway)
            else if (Input.GetKeyDown(KeyCode.E) && (manager.getGameState() == GameState.ATTACK)) {
                Debug.Log("Sah', not safe to go out sah'");
            }*/



            //*debugger code for game state switch
            /*if (Input.GetKeyDown(KeyCode.T)) {
                manager.setGameState(GameState.EXPLORE);
                Debug.Log("Switching gamestate to EXPLORE");
            }*/
        }
        else{
            //play drill stop animation
        }
    }

    public void playerEnter(GameObject input){
        player = input;
        input.SetActive(false);
        playerPresent = true;
        drillCamera.enabled = true;
        playerCamera.enabled = false;
        manager.setGameState(GameState.ATTACK);
    }

    public void playerExit(){
        player.SetActive(true);
        playerPresent = false;
        drillCamera.enabled = false;
        playerCamera.enabled = true;
        player.GetComponent<PlayerMovement>().playerCam.enabled = true;
    }

}
