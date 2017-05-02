using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody Rb;
    public float MaxJumpForce = 250;
    public float MaxSpeed = 100;
    public float HorizontalDrag = 0;
    [Space(20)]

    [Header("PlayerStats")]
    public bool IsGrounded = true;
    public bool IsOnPlatform = false;
    public bool IsOnElevator = false;
    [Space(5)]
    public GameObject RaycastsDown;
    private Transform[] _downrays = new Transform[3];
    private RaycastHit _hit;
    //IsCannonHit still has to be set on cannon hit imo
    public bool IsCannonHit;
    [Space(20)]

    [Header("Finish")]
    public GameObject ColliderLeft;
    public GameObject ColliderRight;
    [Space(5)]
    public Text WinLeft;
    public Text LoseLeft;
    public Text WinRight;
    public Text LoseRight;
    [Space(5)]
    public ParticleSystem particlesOne;
    public ParticleSystem particlesTwo;
    public ParticleSystem particlesThree;


    // Use this for initialization
    void Start()
    {
        //Set 3 downward raycast transforms
        for (int i = 0; i < _downrays.Length; i++)
        {
            _downrays[i] = RaycastsDown.transform.GetChild(i).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal movement
        if (Input.GetKey("d") || Input.GetButton("Right"))
        {
            Rb.AddForce(MaxSpeed, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("q") ||Input.GetButton("Left"))
        {
            Rb.AddForce(MaxSpeed * -1.0f, 0, 0, ForceMode.VelocityChange);
        }

        //Vertical movement
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Jump"))
        {
            if (IsGrounded == true)
            {
                Rb.AddForce(0, MaxJumpForce, 0, ForceMode.VelocityChange);
                IsGrounded = false;
                IsOnElevator = false;
            }
        }
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(0);
        }

        //Add horizontal drag
        if (Mathf.Abs(Rb.velocity.x) > 0 && Input.GetKey("q") == false && Input.GetKey("d") == false && IsCannonHit == false)
        {
            Rb.AddForce(Rb.velocity.x * -HorizontalDrag, 0, 0, ForceMode.VelocityChange);
        }

        //Raycast Down Debugging
        for (int i = 0; i < _downrays.Length; i++)
        {
            
            if (IsGrounded)
            {
                if (IsOnElevator)
                {
                    Debug.DrawRay(_downrays[i].position, Vector3.down / 40, Color.yellow);
                }
                else
                {
                    Debug.DrawRay(_downrays[i].position, Vector3.down / 40, Color.green);
                }

            }
            else
            {
                Debug.DrawRay(_downrays[i].position, Vector3.down / 40, Color.red);
            }

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Set if on ground
        Debug.Log(collision.collider.tag);
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }

        //Set if on elevator
        if (collision.gameObject.tag == "Elevator")
        {
            IsGrounded = true;
            IsOnElevator = true;
            Debug.Log("Entered Elevator");
        }

        if (collision.gameObject == ColliderLeft.gameObject)
        {
            WinLeft.enabled = true;
            LoseRight.enabled = true;
            Object.Destroy(ColliderLeft);
            Object.Destroy(ColliderRight);
            StartCoroutine(StartTheFireWorks());
        }

        if (collision.gameObject == ColliderRight.gameObject)
        {
            WinRight.enabled = true;
            LoseLeft.enabled = true;
            Object.Destroy(ColliderLeft);
            Object.Destroy(ColliderRight);
            StartCoroutine(StartTheFireWorks());
        }
    }
    private IEnumerator StartTheFireWorks()
    {
        while (true)
        {
            particlesOne.Play();
            yield return new WaitForSeconds(1f);
            particlesTwo.Play();
            particlesThree.Play();
        }
    }
}
