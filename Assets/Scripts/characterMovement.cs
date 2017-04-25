using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour {

    public Rigidbody Rb;
    public float MaxJumpForce = 250;
    public float MaxSpeed = 100;
    public float HorizontalDrag = 0;
    bool IsGrounded = true;

    //IsCannonHit still has to be set on cannon hit imo
    public bool IsCannonHit;



	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //Horizontal movement
        if (Input.GetKey("d"))
        {
            Rb.AddForce(MaxSpeed, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("q"))
        {
            Rb.AddForce(MaxSpeed*-1.0f, 0, 0, ForceMode.VelocityChange);
        }

        //Vertical movement
        if (Input.GetKey("space"))
        {
            if (IsGrounded == true)
            {
                Rb.AddForce(0, MaxJumpForce, 0, ForceMode.VelocityChange);
                IsGrounded = false;
            }
        }

        //Add horizontal drag
        if (Mathf.Abs(Rb.velocity.x) > 0 && Input.GetKey("q") == false && Input.GetKey("d") == false && IsCannonHit == false)
        {
            Rb.AddForce(Rb.velocity.x*-HorizontalDrag, 0, 0, ForceMode.VelocityChange);
        }

	}
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            IsGrounded = true;    
        }
    }
}
