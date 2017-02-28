using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public Vector3 RelativePos= new Vector3(0,0,0);
    private Vector3 _finPosition;
    private Vector3 _startPosition;

    public float Percentages = 0;
    public GameObject Level;
    
	// Use this for initialization
	void Start ()
    {
        if (Level == null)
        {
            Level = GameObject.Find("Level_001");
        }
        _startPosition = transform.position;

	    _finPosition = transform.position;
	    //_finPosition.x = _finPosition.x -= Length;

	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = Vector3.Lerp(_startPosition+ Level.transform.position, Level.transform.position+ _startPosition+RelativePos, Percentages/400.0f);

    }
    public void SetPercentages(float rotation)
    {

        Percentages=Mathf.Abs(rotation)/160*400;

    }

    public void  Increment()
    {
        Percentages+=3;
    }

    public void Decrement()
    {
        Percentages-=3;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag== "PlatfornPlayer")
        {
            other.transform.parent = transform;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlatfornPlayer")
        {
            other.transform.parent = Level.transform;
        }
    }

}
