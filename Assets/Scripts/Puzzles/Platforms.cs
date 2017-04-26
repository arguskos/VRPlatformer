using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Material Mat;
    public Material Ghost;
    public GameObject Child;
    private bool _isGhost;
    private float _decayTimer;
    public float DecayTime=4;
    public float ShakeTime = 3;
    private Vector3 _initPosition;
	// Use this for initialization
	void Start ()
	{
	    _isGhost = true;
        _initPosition=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_decayTimer > 0)
	    {
	        _decayTimer -= Time.deltaTime;
	        if (_decayTimer < ShakeTime)
	        {
                //   transform.position = new Vector3(transform.position.x+ Mathf.Sin(Time.time * 0.1f), transform.position.y+ Mathf.Sin(Time.time * 0.1f), transform.position.z+ Mathf.Sin(Time.time * 0.1f));
                transform.position = new Vector3(_initPosition.x+ Mathf.Sin(20*Random.Range(-Time.time,Time.time))* 0.05f, _initPosition.y + Mathf.Sin(20 * Random.Range(-Time.time, Time.time)) * 0.05f, _initPosition.z + Mathf.Sin(20 * Random.Range(-Time.time, Time.time)) * 0.05f);

            }
            if (_decayTimer <= 0)
	        {
	            MakeGhost();
	            transform.position = _initPosition;
	        }
        }
	}

  
    public void MakeReal()
    {
        _isGhost = false;
        Child.GetComponent<Renderer>().material = Mat;
        Child.GetComponent<Pulsating>().enabled = false;
        GetComponent<BoxCollider>().isTrigger = false;
        _decayTimer = DecayTime;
    }
    public void MakeGhost()
    {
        Child.GetComponent<Renderer>().material = Ghost;
        Child.GetComponent<Pulsating>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = true;

    }
}
