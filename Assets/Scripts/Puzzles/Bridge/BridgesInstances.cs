using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgesInstances : MonoBehaviour {

    // Use this for initialization
    public GameObject[] BrifgeType1;
    public GameObject[] BrifgeType2;
    public GameObject[] BrifgeType3;

    public static BridgesInstances Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == null)
            Instance = null;

    }
}
