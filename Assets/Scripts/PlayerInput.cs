using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	private CharacterController characterController;
    public GameObject papa;
    private Renderer rend;
    public Vector3 lastPos;

    public float gravity;
    public float jumpSpeed;
    public float moveSpeed;
    private float fallSpeed;
    private float dPos = 0.3726866F;
    private float zSpeed = 0;

	public bool isGrounded;
    private bool movabele;
    private bool ded;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
        this.gameObject.transform.parent = papa.transform;
        rend = this.gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        ded = false;
        movabele = true;
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
        if (movabele)
        {
            float xSpeed = Input.GetAxis("Horizontal");
            if (xSpeed != 0 || zSpeed != 0) characterController.Move(new Vector3(xSpeed, 0, zSpeed) * moveSpeed * Time.deltaTime);
        }
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
		if (!isGrounded && movabele == true) {
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
        if (hit.gameObject.tag == "checkpoint")
        {
            lastPos = hit.gameObject.transform.position;
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "finish")
        {
            hit.gameObject.SendMessage("gameEnd");
        }
        if (hit.gameObject.tag == "ground")
        {
            
        }
    }
    void die() 
    {
        if (transform.position.y <= dPos)
        {
            if (ded == false)
            {
                StartCoroutine(dying());
            }
        }

    }
    public void PushZ(float dir)
    {
        zSpeed = dir;
    }
    private IEnumerator dying() 
    {
        movabele = false;
        Quaternion rot = this.gameObject.transform.rotation;
        rend.enabled  = false;
        yield return new WaitForSeconds(1);
        Instantiate(this.gameObject, lastPos, rot);
        Destroy(this.gameObject);
    }

}
