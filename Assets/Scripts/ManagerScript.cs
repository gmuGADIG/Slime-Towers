using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript gm; //The single ManagerScript that carries over between scenes
    private GameState gameState;
    private bool gamePaused;
    private AudioListener audioManager;
    private int enemyCap; //The max number of enemies to spawn during a wave
    private int enemiesSpawned; //The number of times any spawner has spawned an enemy this wave
    private int enemiesAlive; //The number of enemies currently spawned and alive in the scene
    private Camera playerCam;
    
    private PlayerMovement playerMoveScript;

    public UnityEvent despawnAllEnemies;
    public static UnityEvent StartExplore;
    public static UnityEvent StartAttack;

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
        if(StartExplore == null){
            StartExplore = new UnityEvent();
        }
        if(StartAttack == null){
            StartAttack = new UnityEvent();
        }
        enemiesSpawned = 0;
        enemiesAlive = 0;
        gamePaused = false;
        playerMoveScript = GameObject.Find("O_Player").GetComponent<PlayerMovement>();
        audioManager = FindObjectOfType<AudioListener>();
        setGameState(GameState.EXPLORE);
        
    }

    // Start is called before the first frame update
    void Start() {
        playerCam = GameObject.Find("O_Player").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    /// <summary>
    /// Unlocks the specified area, allowing the player to explore that area.
    /// </summary>
    /// <param name="areaNum">Number representing the area to unlock</param>
    public void UnlockArea(int areaNum) {

    }

    /// <summary>
    /// Sets the current game state to the passed in GameState (Use GameState.STATE)
    /// </summary>
    /// <param name="state">GameState to set the game's state</param>
    /// <param name="sendSignals">Set to false to not invoke signals, which may be preferred when
    /// the state isn't truly changing but needs to be reset (unpausing) </param>
    public void setGameState(GameState state, bool sendSignals = true) {
        this.gameState = state;
        switch (this.gameState) {
            case GameState.EXPLORE:
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                playerMoveScript.canMove = true;
                if (sendSignals) {
                    StartExplore.Invoke();
                }
                break;
            case GameState.ATTACK:
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                playerMoveScript.canMove = false;
                if (sendSignals) {
                    StartAttack.Invoke();
                }
                break;
            case GameState.DIALOGUE:
                Time.timeScale = 1f;
                AudioListener.volume = 0.5f;
                playerMoveScript.canMove = false;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Pauses the game if it is currently unpaused. This does not bring up
    /// the pause menu.
    /// </summary>
    public void pauseGame() {
        if (gamePaused == false) {
            gamePaused = true;
            Time.timeScale = 0f;
            //AudioListener.pause = true;
        }
    }

    /// <summary>
    /// Unpauses the game if it is currently paused. Does not remove the pause
    /// menu.
    /// </summary>
    public void unpauseGame() {
        if (gamePaused == true) {
            gamePaused = false;
            //AudioListener.pause = false;
            setGameState(gameState, false);
        }
    }

    /// <summary>
    /// Returns true if the game is currently paused, false otherwise.
    /// </summary>
    public bool isPaused() {
        return gamePaused;
    }
    /// <summary>
    /// Returns the current GameState of the game
    /// </summary>
    public GameState getGameState() {
        return this.gameState;
    }
    /// <summary>
    /// Sets the max number of enemies spawned within a wave to the passed in value.
    /// Once this number of enemies have been spawned, the
    /// spawners should not spawn any more enemies for the rest of the wave.
    /// This cannot be set while the game is in ATTACK state.
    /// </summary>
    public void setEnemyCap(int num) {
        if (gameState == GameState.ATTACK) {
            throw new System.Exception("Cannot set enemy cap during game's attack phase");
        }
        enemyCap = num;
    }
    /// <summary>
    /// Returns the total number of enemies to be spawned in the current wave.
    /// </summary>
    public int getEnemyCap() {
        return enemyCap;
    }
    /// <summary>
    /// Returns the number of enemies that have been spawned in the wave. Note
    /// that this number includes both alive enemies and spawned enemies that
    /// are currently dead.
    /// </summary>
    public int getEnemiesSpawned() {
        return  enemiesSpawned;
    }
    /// <summary>
    /// Returns the number of enemies currently alive in the scene
    /// </summary>
    public int getEnemiesAlive() {
        return enemiesAlive;
    }
    /// <summary>
    /// Despawns all enemies in the scene, sets the counters for enemiesSpawned
    /// and enemiesAlive to 0
    /// </summary>
    public void resetWave() {
        despawnAllEnemies.Invoke();
        enemiesSpawned = 0;
        enemiesAlive = 0;
    }
    /// <summary>
    /// This method does not spawn an enemy, it only increases the counter for
    /// the number of enemies spawned by 1. Always call incrementEnemiesSpawned
    /// when you spawn enemies.
    /// Throws an exception if increment past enemyCap is attempted
    /// </summary>
    public void incrementEnemiesSpawned() {
        if (enemiesSpawned < enemyCap) {
            enemiesSpawned += 1;
        }
        else {
            throw new System.Exception("Cannot increment enemies spawned past enemy cap");
        }
    }
    /// <summary>
    /// This method does not spawn an enemy, it only increases the counter for
    /// the number of enemies spawned by the passed in value.
    /// Always call incrementEnemiesSpawned when you spawn enemies.
    /// Throws an exception if increment past enemyCap is attempted
    /// </summary>
    public void incrementEnemiesSpawned(uint num) {
        int n = (int)num;
        if (enemiesSpawned + n <= enemyCap) {
            enemiesSpawned += n;
        }
        else {
            throw new System.Exception("Cannot increment enemies spawned past enemy cap");
        }
    }
    /// <summary>
    /// Returns true if at least one more enemy can be spawned in the scene without
    /// going over the enemy cap. Returns false otherwise.
    /// </summary>
    public bool canSpawnEnemy() {
        return enemiesSpawned < enemyCap;
    }
    /// <summary>
    /// Returns true if the passed in number of enemies can be spawned in the scene
    /// without going over the enemy cap. Returns false otherwise.
    /// </summary>
    public bool canSpawnEnemies(uint num) {
        int n = (int)num;
        return (enemiesSpawned + n) <= enemyCap;
    }

}
