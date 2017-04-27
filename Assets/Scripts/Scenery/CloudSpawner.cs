using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public float HorizontalOffset = 200;
    public float VerticalOffset = 200;
    public int MaxCloudAmount = 20;
    public GameObject Cloud_001;
    public GameObject Cloud_002;

    private int _cloudAmount;

    private float _randomTimer;
    private float _randomTimerCeil;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < MaxCloudAmount; i++)
        {
            Generate();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (true)
        {

        }

		
	}

    public void Generate()
    {
        Vector3 rndpos = new Vector3(0,250,1250);

        Vector3 rndrot = new Vector3(-90, Random.Range(-30.0f,30.0f),0);
        float flscale = Random.Range(15.0f, 30.0f);
        Vector3 rndscale = new Vector3(flscale, flscale, flscale);
        GameObject cloud = Instantiate(GetCloud(), gameObject.transform, false);
        cloud.transform.position = rndpos;
        cloud.transform.localEulerAngles = rndrot;
        cloud.transform.localScale = rndscale;
    }

    private GameObject GetCloud()
    {
        float rnd = Random.Range(0.0f, 1.0f);
        if (rnd > 0.3f)
        {
            return Cloud_001;
        }
        else
        {
            return Cloud_002;
        }
    }
}
