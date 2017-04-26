using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {


    private const float SPEED = 0.25f;
    private float distance;
    private int direction = 1;
    private float VIBRATION_DURATION_IN_MILLISECONDS = 25;
    private float VIBRATION_STRENGTH = 0.4f;
    public GameObject RotatingPart;
    public GameObject MovingPart;
    private PhotonView myPhotonView;

    void Start()
    {
        ResetDistance();
        myPhotonView = GetComponent<PhotonView>();

    }

    void ViveGripInteractionStart(ViveGrip_GripPoint gripPoint)
    {
        gripPoint.controller.Vibrate(VIBRATION_DURATION_IN_MILLISECONDS, VIBRATION_STRENGTH);
        GetComponent<ViveGrip_Interactable>().enabled = false;
        StartCoroutine("Move");
    }



    [PunRPC]
    public void Lol()
    {
        StartCoroutine(Move());
    }

    public void NetworkMove()
    {
        myPhotonView.RPC("Lol", PhotonTargets.All);

    }
    IEnumerator Move()
    {
        while (distance > 0)
        {
            Increment();
            yield return null;
        }
        yield return StartCoroutine("MoveBack");
    }

    IEnumerator MoveBack()
    {
        direction *= -1;
        ResetDistance();
        while (distance > 0)
        {
            Increment();
            yield return null;
        }
        direction *= -1;
        ResetDistance();
        GetComponent<ViveGrip_Interactable>().enabled = true;
    }

    void Increment()
    {
        float increment = Time.deltaTime * SPEED;
        increment = Mathf.Min(increment, distance);
        MovingPart.transform.Translate(0, 0, increment * -direction);
        RotatingPart.transform.Rotate(new Vector3(1,0,0),(increment)*360);
        transform.localScale= new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z- increment * direction);
        distance -= increment;
    }

    void ResetDistance()
    {
        distance = 0.2f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && GetComponent<ViveGrip_Interactable>().enabled == true)
        {
            GetComponent<ViveGrip_Interactable>().enabled = false;
            StartCoroutine(Move());
        }

    }
}

