using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterMovement : MonoBehaviour {

    public Rigidbody Rb;
    public float MaxJumpForce = 250;
    public float MaxSpeed = 100;
    public float HorizontalDrag = 0;
    public bool IsGrounded = true;

    public Text finish1;
    public Text lose1;
    public Text finish2;
    public Text lose2;
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
        if (Input.GetKeyDown("space"))
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
        if (Physics.Raycast(transform.position, Vector3.right, 0.5f))
        {
            if (IsGrounded == false)
            {
                IsGrounded = true;
            }
        }

	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            IsGrounded = true;    
        }
        if (collision.gameObject.tag == "finish1")
        {
            finish1.enabled = true;
            lose2.enabled = true;
        }
        if (collision.gameObject.tag == "finish2")
        {
            finish2.enabled = true;
            lose1.enabled = true;
        }
    }
}
