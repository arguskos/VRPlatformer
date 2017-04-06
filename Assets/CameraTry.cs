using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTry : MonoBehaviour {

    // Use this for initialization
    public GameObject Pos;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Pos.transform.position;
        transform.rotation = Pos.transform.rotation;

    }
}
