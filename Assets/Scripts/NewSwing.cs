using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSwing : Photon.PunBehaviour
{

    // Use this for initialization
    private Rigidbody _rigid;
    private Vector3 _pos;
    private bool _isRight = true;
    public float Speed = 5;
    public GameObject Swing;
    public int PlayerID;
    void Start()
    {
        NetWorkManager.Instance.OnJoined += OnJoined;
        enabled = false;
    }
    public void OnJoined(int id)
    {
        if (id == PlayerID)
        {
            Swing = PhotonNetwork.Instantiate("SwingNetwork", transform.position, transform.rotation, 0);
            _rigid = Swing.GetComponent<Rigidbody>();
            _pos = Swing.transform.position;
            enabled = true;
        }


    }
    private void Update()
    {
        Swing.transform.position = _pos;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //// _rigid.AddForce(Vector3.right *Time.deltaTime);
        //    _rigid.AddRelativeTorque(Vector3.right * Time.deltaTime);
        print(Swing.transform.rotation);

        if (_isRight)
        {
            Swing.transform.Rotate(Vector3.right * Speed * Time.deltaTime);
            if (Swing.transform.rotation.x < 0.3f)
            {
                _isRight = false;
            }
        }
        else
        {
            print(Swing.transform.rotation);

            Swing.transform.Rotate(-Vector3.right * Speed * Time.deltaTime);
            if (Swing.transform.rotation.x >= 0.94f)
            {
                _isRight = true;
            }
        }

    }
}
