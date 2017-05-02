using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeNetworkCopy : MonoBehaviour {

	// Use this for initialization
    public GameObject ClientBridge;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (ClientBridge)
	    {
	        transform.position = ClientBridge.transform.position;
	        transform.rotation = ClientBridge.transform.rotation;
	    }

	}
}
