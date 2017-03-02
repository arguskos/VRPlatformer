using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour {

    public ParticleSystem fireworks;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void gameEnd() {
        (gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
        fireworks.Play();
        //start confetticannon
        //toon finish tekst
    }
}
