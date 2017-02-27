using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float Length;
    private Vector3 _finPosition;
    private Vector3 _startPosition;

    public float Percentages = 0;
    
	// Use this for initialization
	void Start ()
    {
        _startPosition = transform.position;

	    _finPosition = transform.position;
	    _finPosition.x = _finPosition.x -= Length;

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(_startPosition, _finPosition, Percentages/100.0f);

    }
    public void SetPercentages(float rotation)
    {
        Percentages=rotation;
    }

    public void  Increment()
    {
        Percentages++;
    }

    public void Decrement()
    {
        Percentages--;
    }
}
