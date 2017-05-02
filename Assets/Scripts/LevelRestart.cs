using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestart : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G))
	    {
            InteractionPlatforms[]  myScript  = GameObject.FindObjectsOfType(typeof(InteractionPlatforms)) as InteractionPlatforms[];
	        for(int i =0; i<myScript.Length;i++)
	        {
                myScript[i].MyPhotonView.RPC("MakeGhost", PhotonTargets.All);


            }
           
        }
	}
}
