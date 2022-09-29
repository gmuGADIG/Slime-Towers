using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    EXPLORE, //Player explores cave, build towers
    ATTACK, //Enemies spawn and attack drill
    DIALOGUE, //Player/enemy movement restricted, but not complete pause.
                //Animations and sounds still play
    PAUSE //Complete pause, animations and sounds stop
}

public class ManagerScript : MonoBehaviour
{
    
    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public GameState getGameState() {
        return this.gameState;
    }
}
