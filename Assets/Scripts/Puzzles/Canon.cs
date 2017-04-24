using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{


    public GameObject CanonBall;
    public float ShootSpeed;
    private float _timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _timer += Time.deltaTime;
	    if (_timer > 2)
	    {
	        _timer = 0;
	        var l=Instantiate(CanonBall, transform.position - new Vector3(0.2f, 0, 0), Quaternion.identity);
            l.AddComponent<CanonBall>();
            l.GetComponent<Rigidbody>().AddForce(-ShootSpeed,0,0,ForceMode.Impulse);
	    }
	}
}
