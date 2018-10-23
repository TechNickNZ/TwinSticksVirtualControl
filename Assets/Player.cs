using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Horizontal:" + CrossPlatformInputManager.GetAxis("Horizontal"));
        Debug.Log("Vertical:" + CrossPlatformInputManager.GetAxis("Vertical"));
        Debug.Log("Fire1:" + CrossPlatformInputManager.GetButton("Fire1"));
        Debug.Log("Fire2:" + CrossPlatformInputManager.GetButton("Fire2"));
        Debug.Log("Fire3:" + CrossPlatformInputManager.GetButton("Fire3"));
        Debug.Log("Jump:" + CrossPlatformInputManager.GetButton("Jump"));
    }
}
