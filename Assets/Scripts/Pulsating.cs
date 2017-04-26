using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsating : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // float intensity = Mathf.PerlinNoise(random, Time.time);

        //GetComponent<Renderer>().material.SetFloat("_EmissiveIntensity", 20);


        Material mat = GetComponent<Renderer>().material;

        float emission = 0.10f + ((Mathf.PingPong(Time.time, 1.0f)) / 6);
        Color baseColor = Color.white; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}