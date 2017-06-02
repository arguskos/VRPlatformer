using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkBridheSpawner : MonoBehaviour {

    // Use this for initialization
    public int ID;
	void Start () {
        NetWorkManager.Instance.OnJoined += OnJoined;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnJoined(int id )
    {
        if (id == 1)
        {
            int counter=0; 
            foreach (Transform child in transform)
            {
                var obj=PhotonNetwork.Instantiate("BridgeSpawner", child.transform.position, Quaternion.identity, 0);
                obj.GetComponent<BridgeSpawner>().Init(ID,counter);
                counter++;

            }

        }
    }
}
