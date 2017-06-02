using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkBridheSpawner : MonoBehaviour
{


    // ID of the spawner 
    public int ID;


    public List<PhotonView> Parents;


    void Start()
    {
        NetWorkManager.Instance.OnJoined += OnJoined;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnJoined(int id)
    {
        //if (id == 1)//only spawn network parents for the first player
        //{
        int counter = 0;
        foreach (Transform child in transform)
        {
            var parent = PhotonNetwork.Instantiate("SpawnerParent", child.transform.position, Quaternion.identity, 0);
            //        //var obj=Instantiate(BridjeSpawner, child.transform.position, Quaternion.identity);
            //        //obj.GetComponent<BridgeSpawner>().Init(ID,counter);
            //        //counter++;
            //        //obj.transform.parent = parent.transform;
            parent.GetComponent<NetworkBeidgeSpawnerSpawner>().SpawnID = counter;
            parent.GetComponent<NetworkBeidgeSpawnerSpawner>().OnJoined(ID);
            counter++;
            Parents.Add(parent.GetPhotonView());
        }

        //}
    }
}
