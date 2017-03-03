using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody _rigidBody;
    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Swing")
        {

        }


        if (collision.gameObject.tag == "Enemy")
        {
            RaycastHit hit;
            Ray r = new Ray(transform.position, -transform.up);
            Physics.Raycast(r, out hit);
            if (hit.collider.tag=="Enemy")
            {
                GameObject.Destroy(hit.collider.gameObject);
            }
           
            //GameObject.Destroy(this);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.collider.tag);
        //Debug.Log(hit.gameObject.tag);
        //Debug.Log(hit.gameObject.name);
        //Debug.Log(hit.collider.name);
        //if (hit.collider.tag == "Swing")
        //{
        //    var v3 = hit.transform.position - transform.position;
        //    var angle = Vector3.Angle(v3, transform.forward);

        //    if (angle > 45.0 && angle < 90.0)
        //        GetComponent<PlayerInput>().PushZ(1);

        //    //GetComponent<CharacterController>().Move(new Vector3(0,0,1) * Time.deltaTime);

        //    if (angle > 90.0f && angle < 135.0f)
        //        GetComponent<PlayerInput>().PushZ(-1);
        //}
    }
}