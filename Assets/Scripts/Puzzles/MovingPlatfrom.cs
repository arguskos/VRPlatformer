using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlatfornPlayer")
        {
        other.transform.parent = transform;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlatfornPlayer")
        {
            other.transform.parent = null;


        }
    }
}
