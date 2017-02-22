    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    bool _isInTheAir;
	// Use this for initialization
	void Start () {

    }
    bool IsGrounded(){
   return Physics.Raycast(transform.position, -Vector3.up, 0.1f + 0.1f);
    }
// Update is called once per frame
void Update () {
        if (Input.GetKeyDown(KeyCode.W)&&IsGrounded())
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0));
            //_isInTheAir = true;


        }
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left*Time.deltaTime/2);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime / 2);

    }
}
