using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrade : MonoBehaviour
{

    // Use this for initialization
    public GameObject Mass;
    private bool _isPlayer = false;
    private float _timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlayer)
        {
            _timer += Time.deltaTime;
            if (_timer>0.1f)
            {
                Mass.GetComponent<Rigidbody>().mass = 3;

            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlatfornPlayer")
        {
            collision.gameObject.transform.parent = transform;
            collision.gameObject.GetComponent<PlayerInput>().isGrounded = true;
            Mass.GetComponent<Rigidbody>().mass = 20;
            _isPlayer = true;
            _timer = 0;
        }

    }
    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "PlatfornPlayer")
        {
            collision.gameObject.transform.parent = null;
            collision.gameObject.GetComponent<PlayerInput>().isGrounded = false;

            // collision.gameObject.GetComponent<PlayerInput>().gravity = 15;
            //Mass.GetComponent<Rigidbody>().mass = 3;
            _isPlayer = false;


        }
    }
}