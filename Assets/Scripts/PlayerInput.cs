using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	private CharacterController characterController;
	public bool isGrounded;
	public float gravity;
	public float jumpSpeed;
	public float moveSpeed;
	private float fallSpeed;
    public Vector3 lastPos;
    public GameObject papa;
    private float dPos = 0.3726866F;
    private bool dHit = false;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
        this.gameObject.transform.parent = papa.transform;
	}
	
	// Update is called once per frame
	void Update () {
        IsGrounded();
        Fall();
        Jump();
        Move();
        die();

    }

	void Move() {
		float xSpeed = Input.GetAxis("Horizontal");
		if(xSpeed != 0) characterController.Move(new Vector3(xSpeed, 0) * moveSpeed * Time.deltaTime);
	}

	void Jump() {
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			fallSpeed = -jumpSpeed;
		}
        if (Input.GetKeyUp("space") && !isGrounded)
        {
            if (characterController.velocity.y > 0)
            {
                fallSpeed = 0;
            }
        }
	}

	void Fall() {
		if (!isGrounded) {
			fallSpeed += gravity * Time.deltaTime;
		} else {
			if(fallSpeed > 0) fallSpeed = 0;
		}
		characterController.Move (new Vector3(0, -fallSpeed) * Time.deltaTime);
	}

	void IsGrounded() {
        RaycastHit hit = new RaycastHit();
		isGrounded = (Physics.Raycast(transform.position, -transform.up,out hit, characterController.height/1.95F));
	}
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "death")
        {
            dHit = true;
        }
        if (hit.gameObject.tag == "checkpoint")
        {
            lastPos = hit.gameObject.transform.position;
            Destroy(hit.gameObject);
        }
    }
    void die() 
    {
        if (transform.position.y <= dPos || dHit == true)
        {
            Quaternion rot = this.gameObject.transform.rotation;
            Instantiate(this.gameObject, lastPos, rot);
            Destroy(this.gameObject);
        }

    }

}
