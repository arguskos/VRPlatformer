using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
    public GameObject PlayerBody;

    private Rigidbody _playerRigid;
    private bool _inAir = false;
	void Start ()
	{
	    _playerRigid = PlayerBody.GetComponent<Rigidbody>();
	}
    IEnumerator Jump()

    {
        for (int i =0;i<10;i++ )
        {
            PlayerBody.transform.position += new Vector3(0, 2.5f, 0) * Time.deltaTime;

            yield return null;
        }
    }
    // Update is called once per frame
    void Update () {
        float length = 0.1f;
        Vector3 pos = PlayerBody.transform.position - new Vector3(0, 0.13f, 0);

        if (Input.GetKey(KeyCode.A)&&!Physics.Raycast(pos, transform.right, length))
	    {
	        transform.Rotate(new Vector3(0,-20,0)*Time.deltaTime);
	    }
        if (Input.GetKey(KeyCode.D)&&!Physics.Raycast(pos, -transform.right, length))
        {
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime);
            if(!_inAir)
                StartCoroutine("Jump");
        }
        length = 0.01f;
        Debug.DrawRay(pos, PlayerBody.transform.right* length, Color.red);

        if (!(Physics.Raycast(pos, -PlayerBody.transform.up*length, length)))
        {
            //print("hm");
            PlayerBody.transform.position -= new Vector3(0, 0.6f, 0)*Time.deltaTime;
            _inAir = true;
        }
        else
        {
            _inAir = false;
        }
    }
}
