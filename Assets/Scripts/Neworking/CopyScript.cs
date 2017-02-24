using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : Photon.MonoBehaviour {

	// Use this for initialization
    public int Index = 1;

	// Update is called once per frame
	void Update () {
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


            }
	       
        }
    }
}
