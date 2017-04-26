using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    private float _rotPrevFrame;
    private Rigidbody _body;
    // Use this for initialization
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position - new Vector3(0.08f, 0.1f, 0), transform.right);
        //Debug.DrawRay(transform.position - new Vector3(0.0f, 0.1f, 0), transform.right);

        //Debug.DrawRay(transform.position - new Vector3(-0.08f, 0.1f, 0), transform.right);
        if (_body.angularVelocity.magnitude < 1)
        {
            _body.AddForce(Vector3.right * -100990095,ForceMode.Impulse);

        }
        if (_rotPrevFrame > 0 && _rotPrevFrame < 15)
        {
            if (_rotPrevFrame - transform.eulerAngles.z < 0)
            {


                _body.AddForce(Vector3.right*-5000);
            }
            else
            {
                _body.AddForce(Vector3.right*5000);

            }
        }
        _rotPrevFrame = transform.eulerAngles.z;
    }

    void OnCollisionEnter(Collision collision)
    {

        {
            if (collision.gameObject.tag == "PlatfornPlayer")
            {
                //_body.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeRotationX| RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezeRotationZ;

            }
        }
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position - new Vector3(0.08f, 0.1f, 0), transform.right, out hit)
        //                    || Physics.Raycast(transform.position - new Vector3(0, 0.1f, 0), transform.right, out hit)

        //        || Physics.Raycast(transform.position - new Vector3(-0.08f, 0.1f, 0), transform.right, out hit))






        //    if (Physics.Raycast(transform.position - new Vector3(0.09f, 0.1f, 0), -transform.right, out hit)
        //                                || Physics.Raycast(transform.position - new Vector3(0, 0.1f, 0), -transform.right, out hit)

        //        || Physics.Raycast(transform.position - new Vector3(-0.08f, 0.1f, 0), -transform.right, out hit))
        //    {
        //        if (collision.gameObject.tag == "PlatfornPlayer")
        //        {
        //            collision.gameObject.GetComponent<PlayerInput>().PushZ(-1);

        //        }
        //    }

        //}
    }
}