using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour {

    public GameObject PlayerBody;
    private Rigidbody _playerRigid;
    private float mSpeed = 0;
    public float jumpForce = 100;
    private bool grounded;
    public float maxSpeed = 2.5F;
    public float maxForce = 2.5F;
    private float startSpeed = 0;
    public float acceleration = 1f;
    public float deceleration = 1.5f;
    private Vector3 direction;
    private bool lReleased = true;
    private bool rReleased = true;
    private bool falling = false;
    public Vector3 lastPos;
    private bool canMoveR = true;
    private bool canMoveL = true;

	// Use this for initialization
	void Start () {
        _playerRigid = PlayerBody.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (grounded == true)
        //{
        //    maxForce = 5F;
        //}
        //if (grounded == false)
        //{
        //    maxForce = 1F;
        //}
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
        //transform.Translate(direction * mSpeed * Time.deltaTime);
        _playerRigid.velocity += (direction * mSpeed * Time.deltaTime).normalized * 0.5f;
        //Debug.Log(_playerRigid.velocity.magnitude);
        if (_playerRigid.velocity.magnitude > maxForce)
        {
            _playerRigid.velocity += direction * (maxSpeed - _playerRigid.velocity.magnitude);
        }


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
                Vector3 newVelo = new Vector3(0F, 0F - _playerRigid.velocity.y, 0F);
                _playerRigid.velocity += newVelo;
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
