using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour {

	// Use this for initialization
    public int Side;
    public Vector3 Target;
    private float _maxDistance = 0.1f;
    private float _maxVelocity = 1f;
    private bool _isInPlace=true;
    private Rigidbody _body;
	void Start () {
        _body = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {
        if (!_isInPlace)
        {
            var dist = Vector3.Distance(Target, transform.position);

            if (dist > _maxDistance+0.04f)
            {
                float temp = _body.velocity.y;
                _body.velocity = -(Target - transform.position).normalized * (_maxVelocity * (1.0f - dist / _maxDistance));
                _body.velocity =new Vector3(_body.velocity.x,temp,_body.velocity.z); 
            }
            else
            {
                print("finihsed");
                _body.velocity = Vector3.zero;
                transform.position = Target;
                transform.rotation=Quaternion.identity;
                _isInPlace = true;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            _isInPlace = false;
          
        }
        if (other.tag == "Swing")
        {
                    Target=new Vector3(transform.position.x,transform.position.y-0.3f,transform.position.z);

        }
    }
       
    void OnTriggerStay(Collider other)
    {
     
    }
}
