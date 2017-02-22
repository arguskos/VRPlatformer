using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
    public GameObject PlayerBody;

    private Rigidbody _playerRigid;
	void Start ()
	{
	    _playerRigid = PlayerBody.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
	    {
	        transform.Rotate(new Vector3(0,-20,0)*Time.deltaTime);
	    }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime);
            _playerRigid.AddForce(new Vector3(0,90,0));
        }

    }
}
