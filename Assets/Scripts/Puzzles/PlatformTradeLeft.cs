using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTradeLeft : MonoBehaviour {

	// Use this for initialization
    private HingeJoint _parent;
	void Start ()
	{
	    _parent = GetComponentInParent<HingeJoint>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("olo");
        _parent.useMotor = true;
        JointMotor motor = _parent.motor;
        motor.force = 20;
        motor.targetVelocity = 20;
        //motor.freeSpin = false;
        _parent.motor = motor;
        
    }
}
