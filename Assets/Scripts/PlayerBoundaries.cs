using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour {

	// Use this for initialization
    public int Side;
    public Vector3 Target;
    private float _maxDistance = 0.01f;
    private float _maxVelocity = 0f;
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

            if (dist > _maxDistance+0.3f)
            {
                float temp = _body.velocity.y;
                _maxVelocity+=0.8f;
                _body.velocity = (Target - transform.position).normalized * (_maxVelocity)*dist;
                _body.velocity =new Vector3(_body.velocity.x,temp,_body.velocity.z); 
            }
            else
            {
                print("finihsed");
                _body.velocity = Vector3.zero;
                _maxVelocity = 0;
                transform.position = Target;
                transform.rotation=Quaternion.identity;
                _isInPlace = true;
                _body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            _isInPlace = false;
          
        }
        if (other.tag == "Obstacle")
        {
            _body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            Target = new Vector3(transform.position.x,transform.position.y-0.8f,transform.position.z);

        }
    }
       
    void OnTriggerStay(Collider other)
    {
     
    }
}
