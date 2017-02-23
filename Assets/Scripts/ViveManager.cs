using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class ViveManager : MonoBehaviour
{

    public GameObject Head;
    public GameObject LeftHand;
    public GameObject RightHand;

    public static ViveManager Instance;

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
