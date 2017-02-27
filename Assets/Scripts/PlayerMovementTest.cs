using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour {

    public GameObject PlayerBody;
    private Rigidbody _playerRigid;
    private float mSpeed = 0;
    private float jumpForce = 200;
    private bool grounded;
    private float maxSpeed = 5;
    private float startSpeed = 0;
    private float acceleration = 0.1f;
    private float deceleration = 1f;
    private Vector3 direction;
    private bool lReleased = true;
    private bool rReleased = true;
    private bool falling = false;
    public Vector3 lastPos;

	// Use this for initialization
	void Start () {
        _playerRigid = PlayerBody.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp("left"))
	    {
		    lReleased = true;
	    }
        if (Input.GetKeyUp("right"))
	    {
		    rReleased = true;
	    }
        if (mSpeed < maxSpeed && Input.GetKey("left") || mSpeed < maxSpeed && Input.GetKey("right"))
        {
            if (Input.GetKey("left"))
            {                    
                direction = Vector3.left;
                lReleased = false;
            }
            else if (Input.GetKey("right"))
            {
                direction = Vector3.right;
                rReleased = false;
            }
            mSpeed = mSpeed + acceleration;
        }
        else if (rReleased && lReleased)
        {
            mSpeed = mSpeed - deceleration;
            if (mSpeed <= 0)
            {
                mSpeed = 0;
                direction = Vector3.zero;
            }
        }        
        transform.Translate(direction * mSpeed * Time.deltaTime);


        if (Input.GetKeyDown("space"))
        {
            if (grounded)
            {
                _playerRigid.AddForce(Vector3.up * jumpForce);
                grounded = false;
            }            
        }
        if (Input.GetKeyUp("space"))
        {
            if (_playerRigid.velocity.y > 0)
            {                
                _playerRigid.velocity = Vector3.zero;
            }
        }

    }
    void OnCollisionEnter(Collision collision) 
    {
        grounded = true;
    }
    void enteredCheckPoint(Vector3 check) 
    {
        lastPos = check;
    }
}
