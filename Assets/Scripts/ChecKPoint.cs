using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecKPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.SendMessage("enteredCheckPoint",transform.position);
    }
}
