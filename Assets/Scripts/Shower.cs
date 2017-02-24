using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour {

    // Use this for initialization
     //float timer = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //timer += Time.deltaTime;

	}
    private void OnTriggerEnter(Collider other)
    {
       // if (timer > 0.000000003)
     //   {
            Debug.Log(other.tag);
            if (other.tag == "Platform")
            {
              //  timer = 0;

                other.GetComponent<Renderer>().enabled = false;
            }
     //   }

    }
         private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Platform")
        {
            other.GetComponent<Renderer>().enabled = true;
        }
    }
}
