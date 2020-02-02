using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
}
