using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {

	// Use this for initialization
    public GameObject Player;
    public GameObject Rigid;
    private GameObject _level;
	void Start () {
        if (_level == null)
        {
            _level = GameObject.Find("Level_001");
        }
    }
	
	// Update is called once per frame
	void Update () {
        Rigid.transform.Rotate(0,0.4f,0);
	    if (Player)
	        Player.transform.eulerAngles = Vector3.zero;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlatfornPlayer")
        {
            other.gameObject.transform.parent = Rigid.transform;
            Player = other.gameObject;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlatfornPlayer")
        {
            other.gameObject.transform.parent = _level.transform;
            Player = null;

        }

    }
}
