using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallCopy : MonoBehaviour {

    public GameObject ClientBall;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ClientBall)
        {
            transform.position = ClientBall.transform.position;
            transform.rotation = ClientBall.transform.rotation;
        }

    }
}
