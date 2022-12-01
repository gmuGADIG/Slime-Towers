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
            if (waves.Count > 0)
            {
                return waves[0].active;
            }
            return false;
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
        if (waves.Count > 0)
        {
            waves.RemoveAt(0);
        }
    }
}
