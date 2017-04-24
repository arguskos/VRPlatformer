using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collision)
    {
       if (collision.tag != "Platform")
        {
            if (collision.tag == "PlatfornPlayer")
            {
                collision.GetComponent<Rigidbody>().AddForce(new Vector3(-50.5f,0,0));
            }
            Destroy(gameObject);
        }
    }
}
