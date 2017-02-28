using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSlider : MonoBehaviour
{

    public GameObject Level;
	// Use this for initialization
	void Start () {
        if (Level == null)
        {
            Level = GameObject.Find("Level_001");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlatfornPlayer")
        {
            collision.gameObject.transform.parent = transform;

        }

    }
    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "PlatfornPlayer")
        {
            collision.gameObject.transform.parent =null;

        }
    }

}
