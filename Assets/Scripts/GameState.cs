using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState {
    EXPLORE, //Player explores cave, build towers
    ATTACK, //Enemies spawn and attack drill
    DIALOGUE //Player/enemy movement restricted, but not complete pause.
                //Animations and sounds still play
}