using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // scripts[] holds all the scripts used by the NPC
    // scripts[][] holds all lines of said script
	string[][] scripts = new string[5][];
    int myScript = -1;
    int currIndex = 0;

	public Text screenText;

	void Start()
	{
	    scripts[0] = new string[]{ "ahahaha" };
	}

	void Update()
	{
        if( Input.GetKeyDown("space") )
        {
            BeginText(0);
        }
        if ( myScript != -1 ) {
            ContinueText();
        }
	}

	void BeginText( int scriptID )
	{
        myScript = scriptID;
        screenText.text = scripts[myScript][0];
	}

    void ContinueText()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            currIndex += 1;
            if ( currIndex >= scripts[myScript].Length )
            {
                myScript = -1;
                currIndex = 0;
                screenText.text = " ";
            }
            else
            {
                screenText.text = scripts[myScript][currIndex];
            }
        }
    }

}