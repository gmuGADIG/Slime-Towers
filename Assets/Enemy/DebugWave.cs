using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWave : MonoBehaviour
{
    WaveManager waveManager;
    // Start is called before the first frame update
    void Start()
    {
        waveManager = GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (!waveManager.active && GUILayout.Button("Start Wave"))
        {
            waveManager.StartWave();
        }
    }
}
