using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
[RequireComponent(typeof(PhotonView))]

public class Canon : MonoBehaviour
{
    [Header("Animation")]
    public Transform CannonMesh;
    public Vector3 ShootAnimScale;
    public float ShootAnimTime;
    [Space(20)]

    [Header("Shooting")]
    public CanonBall CanonBall;

    public GameObject NetworkBall;
    public float ShootSpeed;
    public float Cooldown = 2.0f;
    private float _timer;
    public int  Side=1;
    private PhotonView _myPhotonView;
    public static List<GameObject> CannonBalls= new List<GameObject>();
	// Use this for initialization
	void Start () {
	   _myPhotonView = GetComponent<PhotonView>();

	}
	
    [PunRPC]
    public void DoNetwork()
    {
       _timer = 0;
            //var l=Instantiate(CanonBall, transform.position - new Vector3(0.2f*Side, 0, 0), Quaternion.identity);
        if (PhotonNetwork.connectionState == ConnectionState.Connected)
        {
            var l = PhotonNetwork.Instantiate(NetworkBall.name, transform.position - new Vector3(0.2f*Side, 0, 0),
                Quaternion.identity, 0);
            //  l.Component.GetComponent<CanonBall>().Direction=Side;
            var b= Instantiate(CanonBall, transform.position - new Vector3(0.2f * Side, 0, 0), Quaternion.identity);
            b.NetworkBall = l.GetPhotonView();
            CannonBalls.Add(b.gameObject);


        }
    }
	// Update is called once per frame
	void Update ()
	{

	    _timer += Time.deltaTime;

        //Apply pre-cannonball shooting animation
        if (_timer > (Cooldown - ShootAnimTime/4))
        {
            iTween.PunchScale(CannonMesh.gameObject, ShootAnimScale, ShootAnimTime);
        }

        //Shoot cannonball
	    if (_timer > Cooldown)
	    {
	           // _myPhotonView.RPC("DoNetwork", PhotonTargets.All);
               DoNetwork();
            //l.GetComponent<Rigidbody>().AddForce(-ShootSpeed,0,0,ForceMode.Impulse);
	    }
	}
}
