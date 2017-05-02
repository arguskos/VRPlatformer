using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBridges : ViveGrip_Grabbable {
    public int BridgeID;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<InteractionPlatforms>()&& other.GetComponent<InteractionPlatforms>().BridgeID==BridgeID&& !Grabbed)
        {
            GetComponent<Renderer>().enabled = false;
            other.GetComponent<InteractionPlatforms>().MyPhotonView.RPC("MakeReal", PhotonTargets.All);
        }
    }
}
