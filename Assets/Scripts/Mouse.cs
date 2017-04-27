using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

	// Use this for initialization
    public Camera Cam;
    private GameObject _clicked;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            var ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit ;
	    if (Input.GetMouseButtonDown(0))
	    {
	        if (Physics.Raycast(ray, out hit))
	        {
	            print(hit.collider.name);
	            //if (hit.collider.tag == "Obstacle")
	            //{
	                print(hit.collider.name);
	                if (hit.collider.GetComponent<Swing>())
	                {
	                    hit.collider.GetComponent<Swing>().MyPhotonView.RPC("NetworkInteraction", PhotonTargets.All);
                        _clicked = hit.collider.gameObject;
	                }
                    else if (hit.collider.GetComponent<Platforms>())
                    {
                        hit.collider.GetComponent<Platforms>().Click();
                    }
                    else if (hit.collider.GetComponent<Pusher>())
	                {
	                    hit.collider.GetComponent<Pusher>().NetworkMove(); 
	                }
                    //hit.collider.gameObject now refers to the 
                    //cube under the mouse cursor if present
                //}
	        }

	    }
	 
	    if (Input.GetMouseButtonUp(0))
	    {
	        if (_clicked)
	        {
                if (_clicked.GetComponent<Swing>())
                {
                    _clicked.GetComponent<Swing>().MyPhotonView.RPC("NetworkFinishInteraction", PhotonTargets.All);//.NetworkFinishInteraction();
                }
            }
	    }

	}
}
