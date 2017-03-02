using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class ObjectsId : MonoBehaviour
{

    public bool IsGhost = false;
    public bool IsObject = true;
    private bool _inPlace = false;

    public GameObject ControllObject;
    public GameObject Child;
    public GameObject  DependentCircle;
    
    public Material ReplacerMat;
    private float _prevFrameRot;
    public int Id;
	// Use this for initialization
	void Start () {
        //GetComponent<Renderer>().material = ReplacerMat;

    }

    // Update is called once per frame
    void Update () {
        if (ControllObject  )//&& GetComponent<ViveGrip_Grabbable>().Grabbed)
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
        if (other.GetComponent<InteractId>())
        {
            if (other.GetComponent<InteractId>().Id == Id && !other.GetComponent<ViveGrip_Grabbable>().Grabbed)
            {
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
