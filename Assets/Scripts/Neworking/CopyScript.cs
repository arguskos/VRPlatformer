using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : Photon.MonoBehaviour
{

    // Use this for initialization
    public int Index = 1;




    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            switch (Index)
            {
                case 1:
                    transform.position = ViveManager.Instance.Head.transform.position;
                    transform.rotation = ViveManager.Instance.Head.transform.rotation;

                    break;
                case 2:
                    transform.position = ViveManager.Instance.LeftHand.transform.position;
                    transform.rotation = ViveManager.Instance.LeftHand.transform.rotation;

                    break;
                case 3:
                    transform.position = ViveManager.Instance.RightHand.transform.position;
                    transform.rotation = ViveManager.Instance.RightHand.transform.rotation;
                    break;
                case 4:
                    transform.position = ViveManager.Instance.Player.transform.position;
                    transform.rotation = ViveManager.Instance.Player.transform.rotation;
                    break;
                //case 5:



                //    foreach (var bridge in BridgeSpawner.BridgesTypes[0])
                //    {
                //        transform.position = bridge.transform.position;
                //        transform.rotation = bridge.transform.rotation;
                //    }
                //    break;

                //case 6:
                //    foreach (var bridge in BridgeSpawner.BridgesTypes[1])
                //    {
                //        transform.position = bridge.transform.position;
                //        transform.rotation = bridge.transform.rotation;
                //    }
                //    break;
                //case 7:

                //    foreach (var bridge in BridgeSpawner.BridgesTypes[2])
                //    {
                //        transform.position = bridge.transform.position;
                //        transform.rotation = bridge.transform.rotation;
                //    }
                //    break;
                    //  foreach (var bridge in BridgesInstances.Instance.BrifgeType1)
                    //  {
                    //      transform.position = bridge.transform.position;
                    //      transform.rotation =bridge.transform.rotation;
                    //  }



                    //break;
                    //case 6:
                    //    foreach (var bridge in BridgesInstances.Instance.BrifgeType2)
                    //    {
                    //        transform.position = bridge.transform.position;
                    //        transform.rotation = bridge.transform.rotation;
                    //    }

                    //    break;
                    //case 7:
                    //    foreach (var bridge in BridgesInstances.Instance.BrifgeType3)
                    //    {
                    //        transform.position = bridge.transform.position;
                    //        transform.rotation = bridge.transform.rotation;
                    //    }
                    //    break;
            }

        }
    }
    public static int PlayerCounter = 0;

    void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        PlayerCounter++;

        Debug.Log("OnPhotonPlayerConnected: " + player);

        // when new players join, we send "who's it" to let them know
        // only one player will do this: the "master"

        if (PhotonNetwork.isMasterClient)
        {
            //TagPlayer(playerWhoIsIt);
        }
    }
}

