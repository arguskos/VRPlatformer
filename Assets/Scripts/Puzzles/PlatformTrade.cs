using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrade : MonoBehaviour
{

    // Use this for initialization
    public GameObject Mass;
    private bool _isPlayer = false;
    private GameObject Player;
    private float _timer;
    private GameObject _level;
    public GameObject YPos;
    void Start()
    {
        if (_level == null)
        {
            _level = GameObject.Find("Level_001");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlayer)
        {
            _timer += Time.deltaTime;
            if (_timer>0.25f)
            {
                Mass.GetComponent<Rigidbody>().mass = 3;

            }
            if (Player)
                Player.transform.position = YPos.transform.position;
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "PlatfornPlayer")
    //    {
    //        collision.gameObject.transform.parent = transform;
    //        collision.gameObject.GetComponent<PlayerInput>().isGrounded = true;
    //        //collision.gameObject.GetComponent<PlayerInput>().gravity = 0;

    //        Mass.GetComponent<Rigidbody>().mass = 20;
    //        _isPlayer = true;
    //        _timer = 0;
    //    }

    //}

    //void OnCollisionExit(Collision collision)
    //{

    //    if (collision.gameObject.tag == "PlatfornPlayer")
    //    {
    //        collision.gameObject.transform.parent = transform;
    //        collision.gameObject.GetComponent<PlayerInput>().isGrounded = true;
    //        //collision.gameObject.GetComponent<PlayerInput>().gravity = 0;

    //        Mass.GetComponent<Rigidbody>().mass = 20;
    //        _isPlayer = true;
    //        _timer = 0;
    //    }
    //}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlatfornPlayer")
        {
            other.gameObject.transform.parent = transform;
            other.gameObject.GetComponent<PlayerInput>().isGrounded = false;
            //collision.gameObject.GetComponent<PlayerInput>().gravity = 0;

            Mass.GetComponent<Rigidbody>().mass = 20;
            _isPlayer = true;
            _timer = 0;
            Player = other.gameObject;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlatfornPlayer")
        {
            other.gameObject.transform.parent = _level.transform;
            other.gameObject.GetComponent<PlayerInput>().isGrounded = false;
            //collision.gameObject.GetComponent<PlayerInput>().gravity = 0;

            Mass.GetComponent<Rigidbody>().mass = 3;
            _timer = 0;
            Player = null;
        }

    }
}