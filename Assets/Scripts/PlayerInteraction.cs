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
        _rigidBody.constraints = RigidbodyConstraints.None;

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
}