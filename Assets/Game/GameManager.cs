using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float fixedDeltaTime;
    private bool isPaused = false;

    private void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        Debug.Log(fixedDeltaTime);
    }

    // Update is called once per frame
    void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if(Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        }
        else if(Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }
	}

    private void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        if (pauseStatus)
        {
            PauseGame();
            Debug.Log("Pausing");
        }
    }
}
