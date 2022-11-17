using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    
    public List<Wave> waves;

    public bool active
    {
        get
        {
            return waves[0]?.active ?? false;
        }
    }

    public Wave currentWave => waves.Count > 0 ? waves[0] : null;

    public void StartWave()
    {
        if(currentWave != null)
        {
            currentWave.StartWave();
            currentWave.onWaveComplete.AddListener(NextWave);
        }
    }

    public void NextWave()
    {
        waves.RemoveAt(0);
    }
}
