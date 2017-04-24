using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour {

    public Rigidbody player;
    public float startSpeed;
    public float Maxspeed = 2;
    public float speedUpTime;
    public int jumpForce = 100;
    public float speed;
    bool grounded = true;

	// Use this for initialization
	void Start () {
        speed = startSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (speed < Maxspeed)
            {
                speed += speedUpTime;
            }
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * -speed);
            if (speed < Maxspeed)
            {
                speed += speedUpTime;
            }
        }
        if (Input.GetKey("space"))
        {
            if (grounded == true)
            {
                player.AddForce(Vector3.up * jumpForce);
                grounded = false;
            }
            
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp("q"))
        {
            speed = startSpeed;
        }

	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "obst")
        {
            grounded = true;    
        }
    }
}
