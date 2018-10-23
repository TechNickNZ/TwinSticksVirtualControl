using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;
    private GameManager manager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (manager.recording == true)
        {
            Record();
        }
        else
        {
            Playback();
        }
    }

    private void Playback()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        Debug.Log("Reading frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = (Time.frameCount % bufferFrames);
        float time = Time.time;
        Debug.Log("writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, rotation and position.
/// </summary>
public struct MyKeyFrame
{
    public float frameTime { get; set; }
    public Vector3 position { get; set; }
    public Quaternion rotation { get; set; }

    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}
