using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerScript : MonoBehaviour
{
    
    private GameState gameState;
    private bool gamePaused;
    private AudioListener audioManager;
    private int enemyCeiling; //The max number of enemies to spawn during a wave
    private int enemiesSpawned; //The number of times any spawner has spawned an enemy this wave
    private int enemiesAlive; //The number of enemies currently spawned and alive in the scene

    public UnityEvent despawnAllEnemies;

    // Start is called before the first frame update
    void Start()
    {
        setGameState(GameState.EXPLORE);
        gamePaused = false;
        audioManager = FindObjectOfType<AudioListener>();
        if (despawnAllEnemies == null) {
            despawnAllEnemies = new UnityEvent();
        }
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
                break;
            case GameState.ATTACK:
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                break;
            case GameState.DIALOGUE:
                Time.timeScale = 1f;
                AudioListener.volume = 0.5f;
                break;
            default:
                break;
        }
    }

    public void pauseGame() {
        if (gamePaused == false) {
            gamePaused = true;
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }

    public void unpauseGame() {
        if (gamePaused == true) {
            gamePaused = false;
            AudioListener.pause = false;
            setGameState(gameState);
        }
    }

    public bool isPaused() {
        return gamePaused;
    }

    public GameState getGameState() {
        return this.gameState;
    }

    public void setEnemyCeiling(int num) {
        enemyCeiling = num;
    }

    public int getEnemyCeiling() {
        return enemyCeiling;
    }

    public int getEnemiesSpawned() {
        return  enemiesSpawned;
    }
    
    public int getEnemiesAlive() {
        return enemiesAlive;
    }

    public void resetWave() {
        despawnAllEnemies.Invoke();
    }

}
