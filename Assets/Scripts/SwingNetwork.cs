using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingNetwork : ViveGrip_Grabbable {
    public NewSwing SwingParent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ViveGripGrabStart(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = true;
        SwingParent.enabled = false;

    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = false;
        SwingParent.enabled = true;

    }
}
