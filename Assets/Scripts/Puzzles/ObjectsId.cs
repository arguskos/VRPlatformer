﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class ObjectsId : MonoBehaviour
{

    public bool IsGhost = false;
    public bool IsObject = true;

    public GameObject ControllObject;
    public GameObject Child;
    public GameObject  DependentCircle;
    
    public Material ReplacerMat;
    private float _prevFrameRot;
    public int Id;
	// Use this for initialization
	void Start () {
        //GetComponent<Renderer>().material = ReplacerMat;
	    if (IsGhost)
	        GetComponent<BoxCollider>().isTrigger = true;
	}

    // Update is called once per frame
    void Update () {
        if (ControllObject   )//&& GetComponent<ViveGrip_Grabbable>().Grabbed)
        {
            //ControllObject.GetComponent<PlatformMovement>().SetPercentages(transform.eulerAngles.z);
            if (_prevFrameRot > transform.eulerAngles.z + 2)
            {
                ControllObject.GetComponent<PlatformMovement>().Decrement();
                DependentCircle.transform.Rotate(new Vector3(0, 0, 1));
            }
            else if (_prevFrameRot < transform.eulerAngles.z - 2)
            {

                ControllObject.GetComponent<PlatformMovement>().Increment();
                DependentCircle.transform.Rotate(new Vector3(0, 0, -1));

            }
            _prevFrameRot = transform.eulerAngles.z;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("lolololsada0");
        if (other.GetComponent<InteractId>()&&IsGhost)
        {
            if (other.GetComponent<InteractId>().Id == Id && !other.GetComponent<ViveGrip_Grabbable>().Grabbed)
            {
                IsObject = true;
                GetComponent<BoxCollider>().enabled = true;

                if (Id==0)
                {
                    GetComponent<ViveGrip_Grabbable>().enabled = true;
                }
                GetComponent<BoxCollider>().isTrigger = false;

                Child.GetComponent<Pulsating>().enabled = false;
                //var l=GameObject.Instantiate(Replacer);
                //l.transform.position = other.transform.position;
                //l.transform.rotation = other.transform.rotation;
                //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                //_inPlace = true;
                //GameObject.Destroy(this);
                Child.GetComponent<Renderer>().material = ReplacerMat;
                GameObject.Destroy(other.gameObject);
            }
        }
    }
}
