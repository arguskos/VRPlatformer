using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatforTrade : MonoBehaviour {

    // Use this for initialization
    public GameObject point1;
    public GameObject point2;

    public GameObject platform1;
    public GameObject platform2;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		platform1.transform.position=new Vector3(platform1.transform.position.x,point2.transform.position.y, platform1.transform.position.z);
        platform2.transform.position = new Vector3(platform2.transform.position.x, point1.transform.position.y, platform2.transform.position.z);
    }
    
}
