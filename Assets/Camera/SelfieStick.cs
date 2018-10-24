﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 10f;

    private Vector3 armRotation;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update () {
        armRotation.y += CrossPlatformInputManager.GetAxis("RHoriz") * panSpeed;
        armRotation.x += CrossPlatformInputManager.GetAxis("RVert") * panSpeed;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
	}
}
