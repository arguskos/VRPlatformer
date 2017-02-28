using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLevel : ViveGrip_Grabbable {

	// Use this for initialization
    public GameObject Level;
    public GameObject Temp;
    private float _zeroingPos;
    public float LevelStartPos=1;
    public float LevelEndPos = 10;
	void Start ()
	{
	    _zeroingPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log((10 - 1)/100.0f * (transform.position.x - _zeroingPos) * 100);
		Level.transform.position=new Vector3((LevelEndPos-LevelStartPos)/100.0f* (transform.position.x - _zeroingPos) * 100, Level.transform.position.y,Level.transform.position.z);
	}

    void ViveGripGrabStart(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = true;
       // var temp = Temp.GetComponent<HingeJoint>();

       // temp.useLimits = false;
        //Temp.GetComponent<Rigidbody>().isKinematic = true;
 

    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {

        Grabbed = false;
       // Temp.GetComponent<Rigidbody>().isKinematic = false;
      //  var temp = Temp.GetComponent<HingeJoint>();

       // temp.useLimits = true;


    }
}
