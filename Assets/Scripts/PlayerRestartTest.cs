using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestartTest :  MonoBehaviour
{

    private Vector3 pPos;
    
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collision)
    {
        GameObject player = collision.gameObject;
        Quaternion rot = player.transform.rotation;

        PlayerMovementTest pScript = player.GetComponent<PlayerMovementTest>();
        pPos = pScript.lastPos;

        Instantiate(player, pPos, rot);
        Destroy(collision.gameObject);

    }
}
