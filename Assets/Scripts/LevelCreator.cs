using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    // Use this for initialization
    public GameObject Pice;
    public GameObject Pice2;
    public GameObject Pice3;
    public GameObject Pice4;


    public float Angle=28;
    public float Angle2 = 22.5f;
    public float Angle3 = 22.5f;
    public float Angle4 = 22.5f;


    private float _angle;
	void Start () {
        for (int i = 0; i < 360 / Angle; i++)
        {
            var rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(-90, _angle, 0);
            _angle += Angle;
            var o = GameObject.Instantiate(Pice, transform.position, rot);
            o.transform.parent = transform;
            if (i == 4)
            {
                o.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        _angle = 0;
        for (int i = 0; i < 360 / Angle2 ; i++)
        {
            var rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(-90, _angle, 0);
            _angle += Angle2;
            var o = GameObject.Instantiate(Pice2, transform.position+new Vector3(0, 0.1f,0), rot);
            o.transform.parent = transform;
            if (i == 4)
            {
                o.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        _angle = 0;

        for (int i = 0; i < 360 / Angle3; i++)
        {
            var rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(-90, _angle, 0);
            _angle += Angle3;
            var o = GameObject.Instantiate(Pice3, transform.position + new Vector3(0, 0.2f, 0), rot);
            o.transform.parent = transform;
            if (i == 4)
            {
                o.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        _angle = 0;

        for (int i = 0; i < 360 / Angle4; i++)
        {
            var rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(-90, _angle, 0);
            _angle += Angle4;
            var o = GameObject.Instantiate(Pice4, transform.position + new Vector3(0, 0.3f, 0), rot);
            o.transform.parent = transform;
            if (i == 4)
            {
                o.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
