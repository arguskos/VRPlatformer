using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkBridheSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NetWorkManager.Instance.OnJoined += OnJoined;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnJoined(int id )
    {
        foreach (Transform child in transform)
        {
            PhotonNetwork.Instantiate("BridgeSpawner", child.transform.position, Quaternion.identity,0);
        }
    }
}
