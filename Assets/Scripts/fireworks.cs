using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireworks : MonoBehaviour {

    [Header("Colliders")]
    public GameObject ColliderLeft;
    public GameObject ColliderRight;
    [Space(5)]
    [Header("UI")]
    public Text WinLeft;
    public Text LoseLeft;
    public Text WinRight;
    public Text LoseRight;
    [Space(5)]
    [Header("Particles")]
    public ParticleSystem particlesOne;
    public ParticleSystem particlesTwo;
    public ParticleSystem particlesThree;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void colldided(byte bit)
    {
        if (bit == 0)
        {
            WinLeft.enabled = true;
            LoseRight.enabled = true;
            Object.Destroy(ColliderLeft);
            Object.Destroy(ColliderRight);
            StartCoroutine(StartTheFireWorks());
        }

        if (bit == 1)
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
