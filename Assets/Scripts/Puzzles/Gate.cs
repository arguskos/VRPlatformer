using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    public GameObject ViveButton;
    public GameObject PressurePlate;
    public bool var1;
    public bool var2;
    public Vector3 RelativePos = new Vector3(0, 0, 0);
    private Vector3 _finPosition;
    private Vector3 _startPosition;

    public float Percentages = 0;
    public GameObject Level;
    // Use this for initialization
    void Start () {
        if (Level == null)
        {
            Level = GameObject.Find("Level_001");
        }
        _startPosition = transform.position;

    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp(_startPosition + Level.transform.position, Level.transform.position + _startPosition + RelativePos, Percentages / 100.0f);

        if (var1&var2)
        {
            if (Percentages+1<100)
                Percentages++;
        }
        else if (Percentages-3>=0)
            Percentages -= 3;
	}
}
