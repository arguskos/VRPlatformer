using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Material Mat;
    public Material GhostMat;
    private bool _isGhost;
    private int _clicks;
    public Transform[] _platformParts = new Transform[8];

    // Use this for initialization
    void Start()
    {
        _isGhost = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
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

    //Changes the material to visible
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
    }

    //public void MakeGhost()
    //{
    //    Child.GetComponent<Renderer>().material = Mat;
    //    Child.GetComponent<Pulsating>().enabled = false;
    //    GetComponent<BoxCollider>().isTrigger = false;

    //}
}
