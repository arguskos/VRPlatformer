using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position - new Vector3(0.08f, 0.1f, 0), transform.right);
        Debug.DrawRay(transform.position - new Vector3(0.0f, 0.1f, 0), transform.right);

        Debug.DrawRay(transform.position - new Vector3(-0.08f, 0.1f, 0), transform.right);

    }

    void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position - new Vector3(0.08f, 0.1f, 0), transform.right, out hit)
                        || Physics.Raycast(transform.position - new Vector3(0, 0.1f, 0), transform.right, out hit)

            || Physics.Raycast(transform.position - new Vector3(-0.08f, 0.1f, 0), transform.right, out hit))





        {
            if (collision.gameObject.tag == "PlatfornPlayer")
            {
                collision.gameObject.GetComponent<PlayerInput>().PushZ(1);

            }
        }

        if (Physics.Raycast(transform.position - new Vector3(0.09f, 0.1f, 0), -transform.right, out hit)
                                    || Physics.Raycast(transform.position - new Vector3(0, 0.1f, 0), -transform.right, out hit)

            || Physics.Raycast(transform.position - new Vector3(-0.08f, 0.1f, 0), -transform.right, out hit))
        {
            if (collision.gameObject.tag == "PlatfornPlayer")
            {
                collision.gameObject.GetComponent<PlayerInput>().PushZ(-1);

            }
        }
       
    }
}