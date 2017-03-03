using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatform : MonoBehaviour
{
    public GameObject Point;
    public GameObject Hinge;
    private GameObject _level;
    public bool IsRight = true;
    // Use this for initialization
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
        if (Point)
            transform.position = new Vector3(transform.position.x, Point.transform.position.y - 1.5f,
                transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlatfornPlayer")
        {
            other.gameObject.transform.parent = transform;
            if (IsRight)
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterR++;
            }
            else
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterL++;

            }
        }
        else if (other.gameObject.GetComponent<Rigidbody>())
        {
            if (IsRight)
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterR++;
            }
            else
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterL++;

            }
        }

    }

    void OnTriggerExit(Collider other)

    {

        if (other.gameObject.tag == "PlatfornPlayer")
        {
            other.gameObject.transform.parent = _level.transform;
            if (IsRight)
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterR--;
            }
            else
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterL--;

            }

        }
        else if (other.gameObject.GetComponent<Rigidbody>())
        {
            if (IsRight)
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterR++;
            }
            else
            {
                Hinge.GetComponent<PlatformTradeNoRigid>().CounterL++;

            }


        }
    }
}