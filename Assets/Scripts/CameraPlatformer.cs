using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlatformer : MonoBehaviour {

	// Use this for initialization
    public GameObject Player;
    public float Speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x,Player.transform.position.y,transform.position.z),Speed* Time.deltaTime);
    }
}
