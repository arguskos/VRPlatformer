﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Material Mat;
    public Material GhostMat;
    public GameObject Child;
    private bool _isGhost;
    private float _decayTimer;
    public float DecayTime=4;

    public float ShakeTime = 3;
    private Vector3 _initPosition;
    public Transform[] _platformParts = new Transform[8];
    private int _clicks;
    // Use this for initialization
    void Start ()
	{
	    _isGhost = true;
        _initPosition=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_decayTimer > 0)
	    {
	        _decayTimer -= Time.deltaTime;
	        if (_decayTimer < ShakeTime)
	        {
                //   transform.position = new Vector3(transform.position.x+ Mathf.Sin(Time.time * 0.1f), transform.position.y+ Mathf.Sin(Time.time * 0.1f), transform.position.z+ Mathf.Sin(Time.time * 0.1f));
                transform.position = new Vector3(_initPosition.x+ Mathf.Sin(20*Random.Range(-Time.time,Time.time))* 0.05f, _initPosition.y + Mathf.Sin(20 * Random.Range(-Time.time, Time.time)) * 0.05f, _initPosition.z + Mathf.Sin(20 * Random.Range(-Time.time, Time.time)) * 0.05f);

            }
            if (_decayTimer <= 0)
	        {
	            MakeGhost();
	            transform.position = _initPosition;
	        }
        }
	}

  

    //Counts how many times this platform has been clicked
    public void Click()
    {
        _clicks++;
        if (_clicks == 1)
        {
            MakeReal();
        }
        else if (_clicks == 2)
        {
            BreakPlatform();
        }
    }

    public void MakeReal()
    {
        _isGhost = false;

        for (int i = 0; i < _platformParts.Length; ++i)
        {
            _platformParts[i].GetComponent<Renderer>().material = Mat;
            _platformParts[i].GetComponent<Pulsating>().enabled = false;
        }
    }

    //Enables collision with ground and changes to pulsating
    //TODO: over time decay with a transparency fade
    public void BreakPlatform()
    {
        _isGhost = true;

        for (int i = 0; i < _platformParts.Length; ++i)
        {
            _platformParts[i].GetComponent<Renderer>().material = GhostMat;
            _platformParts[i].GetComponent<Pulsating>().enabled = true;
            _platformParts[i].GetComponent<Collider>().enabled = true;
            _platformParts[i].GetComponent<Rigidbody>().useGravity = true;
            _platformParts[i].GetComponent<PlatformPart>().IgnoreCollision = true;
        }

        GetComponent<BoxCollider>().isTrigger = false;
        _decayTimer = DecayTime;
    }
    public void MakeGhost()
    {
        Child.GetComponent<Renderer>().material = GhostMat;
        Child.GetComponent<Pulsating>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = true;

    }
}
