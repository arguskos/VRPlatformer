using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTradeNoRigid : MonoBehaviour
{

    public int CounterR;
    public int CounterL;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.rotation.z);
        if (transform.rotation.z>-Mathf.PI/10 && CounterL>CounterR)
		    transform.Rotate(0,0,-CounterL);
        if (transform.rotation.z < Mathf.PI / 10&&CounterR > CounterL)
            transform.Rotate(0, 0, CounterR);
	    if (CounterR == CounterL)
	    {
	        if (transform.rotation.z<0)
                transform.Rotate(0, 0, 0.5f);
            if (transform.rotation.z > 0)
                transform.Rotate(0, 0, 0.5f);
	        if (transform.rotation.z > -0.01f && transform.rotation.z < 0.01f)
	        {
	            transform.rotation = Quaternion.identity;
	        }
        }
    }
}
