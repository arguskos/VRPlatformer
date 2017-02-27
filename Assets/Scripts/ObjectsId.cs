using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class ObjectsId : MonoBehaviour
{

    public bool IsGhost = false;
    public bool IsObject = true;
    private bool _inPlace = false;
    public int Id;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!_inPlace && other.GetComponent<ObjectsId>() && other.GetComponent<ObjectsId>().Id == Id &&
            other.GetComponent<ObjectsId>().IsGhost&&!GetComponent<ViveGrip_Grabbable>().Grabbed)
        {
            transform.position = other.transform.position;
            _inPlace = true;
        }
    }
}
