using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Material Mat;
    public GameObject Child;
    private bool _isGhost;
	// Use this for initialization
	void Start ()
	{
	    _isGhost = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeReal()
    {
        _isGhost = false;
        Child.GetComponent<Renderer>().material = Mat;
        Child.GetComponent<Pulsating>().enabled = false;
        GetComponent<BoxCollider>().isTrigger = false;
    }
    //public void MakeGhost()
    //{
    //    Child.GetComponent<Renderer>().material = Mat;
    //    Child.GetComponent<Pulsating>().enabled = false;
    //    GetComponent<BoxCollider>().isTrigger = false;

    //}
}
