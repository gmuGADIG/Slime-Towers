using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTestButtons : MonoBehaviour
{
    private ManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Manager").GetComponent<ManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attackPressed() {
        gameManager.setGameState(GameState.ATTACK);
    }
    public void explorePressed() {
        gameManager.setGameState(GameState.EXPLORE);
    }
    public void dialoguePressed() {
        gameManager.setGameState(GameState.DIALOGUE);
    }
    public void pausePressed() {
        if (gameManager.isPaused()) {
            gameManager.unpauseGame();
        }
        else {
            gameManager.pauseGame();
        }
    }
}
