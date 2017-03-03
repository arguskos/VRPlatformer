using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : ViveGrip_Grabbable {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //  GetComponent<Rigidbody>().isKinematic = false;

        if (Physics.Raycast(transform.position, -Vector3.up, 0.13f)||Grabbed)
            return;
        transform.Translate(Vector3.Cross(Vector3.right, Vector3.forward) *Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }

 
    void ViveGripGrabStart(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = false;

        GetComponent<Rigidbody>().isKinematic = true;

    }
}
