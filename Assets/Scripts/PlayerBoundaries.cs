using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour {

	// Use this for initialization
    public int Side;
    public GameObject Target;
    private float _maxDistance = 0.01f;
    private float _maxVelocity = 1f;
    private bool _isInPlace=true;
    private Rigidbody _body;
    private float _zPosition;
    private float _zObstaclex;
    protected Vector3 _teleportPos;
    void Start () {
        _body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
      
    }

    void FixedUpdate()
    {
            //if (!_isInPlace)
            //{
            //   // Target=new Vector3(Target.x, Target.y, _zPosition);
            //    var dist = Vector3.Distance(Target, transform.position);

            //    if (dist > _maxDistance+1f)
            //    {
            //        float temp = _body.velocity.y;
            //        _maxVelocity+=3;
            //        _body.velocity = (Target - transform.position).normalized * (_maxVelocity)*(dist);
            //        _body.velocity =new Vector3(_body.velocity.x,temp,_body.velocity.z); 
            //    }
            //    else
            //    {
            //        print("finihsed");
            //        _body.velocity = Vector3.zero;
            //        _maxVelocity = 0;
            //        transform.position = Target;
            //        transform.rotation=Quaternion.identity; 
            //        _isInPlace = true;
            //        _body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            //    }
            //}
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
           // _isInPlace = false;
          
        }
        if (other.tag == "Obstacle"&&_isInPlace)
        {
            _isInPlace = false;
            _body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            _teleportPos = Target.transform.position;
            //Target = new Vector3(transform.position.x,transform.position.y-0.5f,transform.position.z);
            StartCoroutine(Teleport());
            _zObstaclex = other.transform.position.x;
            _zPosition=transform.position.z;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.9f);

        print("lol");
        if (Mathf.Abs(_zPosition-transform.position.z)>0.1)
        {
            transform.position = new Vector3(_zObstaclex,_teleportPos.y,_teleportPos.z);
        }
        _isInPlace = true;
        _body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

    }
    void OnTriggerStay(Collider other)
    {
       
    }
}
