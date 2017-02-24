using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
    public GameObject Enemybody;
    public float Speed=0.1f;
    public float Angle = 10;
    IEnumerator GoLeft()

    {
        //Debug.Log(transform.rotation.y);

        //Debug.Log(transform.eulerAngles.y+"   :"+ (transform.eulerAngles.y + 20) % 360);
        float angle = transform.eulerAngles.y;
        float fin = angle;
        while (angle> fin - Angle)
        {
          

            transform.Rotate(Vector3.up, -Speed * Time.deltaTime);
            angle += -Speed*Time.deltaTime;
            yield return null;
        }

        yield return null;
        StartCoroutine("GoRight");

    }
    IEnumerator GoRight()

    {
        float angle = transform.eulerAngles.y;
        float fin = angle;
        while (angle < fin + Angle)
        {
            Debug.Log(angle);

            Debug.Log(transform.eulerAngles.y);

            transform.Rotate(Vector3.up, Speed * Time.deltaTime);
            angle += Speed * Time.deltaTime;
            yield return null;
        }


        yield return null;
        StartCoroutine("GoLeft");


    }
    void Start ()
    {
        StartCoroutine("GoLeft");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
