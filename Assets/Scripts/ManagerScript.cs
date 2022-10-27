using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    
    private GameState gameState;
    private AudioListener audioManager;

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
                break;
            case GameState.ATTACK:
                Time.timeScale = 1f;
                AudioListener.volume = 1f;
                break;
            case GameState.DIALOGUE:
                Time.timeScale = 1f;
                AudioListener.volume = 0.5f;
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
