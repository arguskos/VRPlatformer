using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsating : MonoBehaviour
{
    private Material _mat;
	// Use this for initialization
	void Start () {
        _mat = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update () {
       // float intensity = Mathf.PerlinNoise(random, Time.time);
       
        //GetComponent<Renderer>().material.SetFloat("_EmissiveIntensity", 20);

       

        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = Color.white; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        _mat.SetColor("_EmissionColor", finalColor);
    }
   
}
