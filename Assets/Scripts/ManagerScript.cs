using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript gm; //The single ManagerScript that carries over between scenes
    private GameState gameState;
    private AudioListener audioManager;
    private int enemyCap; //The max number of enemies to spawn during a wave
    private int enemiesSpawned; //The number of times any spawner has spawned an enemy this wave
    private int enemiesAlive; //The number of enemies currently spawned and alive in the scene
    
    private PlayerMovement playerMoveScript;

    public UnityEvent despawnAllEnemies;

    void Awake() {
        if (gm == null) {
            gm = this;
        }
        else {
            if (gm.gameObject == this.gameObject) {
                Destroy(this);
            }
            else {
                Destroy(this.gameObject);
            }
        }
        if (despawnAllEnemies == null) {
            despawnAllEnemies = new UnityEvent();
        }
        enemiesSpawned = 0;
        enemiesAlive = 0;
        gamePaused = false;
        playerMoveScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        audioManager = FindObjectOfType<AudioListener>();
        setGameState(GameState.EXPLORE);
    }


    // Start is called before the first frame update
    void Start()
    {
        setGameState(GameState.EXPLORE);
        audioManager = FindObjectOfType<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    Unlocks the specified area, allowing the player to explore that area.
    */
    public void UnlockArea(int areaNum) {

    }

    public void setGameState(GameState state) {
        this.gameState = state;
        switch (this.gameState) {
            case GameState.EXPLORE:
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                playerMoveScript.canMove = true;
                break;
            case GameState.ATTACK:
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                playerMoveScript.canMove = false;
                break;
            case GameState.DIALOGUE:
                Time.timeScale = 1f;
                AudioListener.volume = 0.5f;
                playerMoveScript.canMove = false;
                break;
            case GameState.PAUSE:
                Time.timeScale = 0f;
                AudioListener.volume = 0.25f;
                break;
            default:
                break;
        }
    }

    public GameState getGameState() {
        return this.gameState;
    }
}
