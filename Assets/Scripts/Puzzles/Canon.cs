using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [Header("Animation")]
    public Transform CannonMesh;
    public Vector3 ShootAnimScale;
    public float ShootAnimTime;
    [Space(20)]

    [Header("Shooting")]
    public GameObject CanonBall;
    public float ShootSpeed;
    public float Cooldown = 2.0f;
    private float _timer;
    public int  Side=1;
	// Use this for initialization
	void Start () {
		
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
	        _timer = 0;
	        var l=Instantiate(CanonBall, transform.position - new Vector3(0.2f*Side, 0, 0), Quaternion.identity);
            //  l.Component.GetComponent<CanonBall>().Direction=Side;
            l.AddComponent<CanonBall>();
            l.GetComponent<Rigidbody>().AddForce(-ShootSpeed,0,0,ForceMode.Impulse);
	    }
	}
}
