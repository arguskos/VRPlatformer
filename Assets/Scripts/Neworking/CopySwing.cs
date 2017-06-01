using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopySwing : MonoBehaviour {

    // Use this for initialization
    public GameObject Client;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Client)
        {
            transform.position = Client.transform.position;
            transform.rotation = Client.transform.rotation;
        }
    }
}
