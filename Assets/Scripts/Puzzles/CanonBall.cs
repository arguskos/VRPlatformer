using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {
    private float _direction = 1.0f;
    private float _strength = 350.0f;
    private float _speed = 10;
    public PhotonView NetworkBall;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x + (_speed * _direction * Time.deltaTime), transform.position.y, transform.position.z);
    }
    public void SetBall(int direction, float speed)
    {
        _direction = direction;
        _speed = speed;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ground" || collision.tag == "PlatfornPlayer")
        {
            if (collision.tag == "PlatfornPlayer")
            {
                collision.GetComponent<Rigidbody>().AddForce(new Vector3(_strength * -_direction, 0, 0));
            }
            PhotonNetwork.Destroy(NetworkBall);
            Destroy(this.gameObject);
        }
     
    }
}
