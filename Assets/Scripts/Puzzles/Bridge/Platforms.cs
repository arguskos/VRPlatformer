using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Material Mat;
    public Material GhostMat;


    // Use this for initialization
    void Start ()
	{

        MakeGhost();

    }

    public void MakeReal()
    {

        var parts = GetComponentsInChildren<Renderer>();

        foreach (Renderer joint in parts)
        {
            joint.material = Mat;
        }

    }
   
    //Enables collision with ground and changes to pulsating


   
    public void MakeGhost()
    {
        var parts = GetComponentsInChildren<Renderer>();

        foreach (Renderer joint in parts)
        {
            joint.material = GhostMat;
        }
    }
}
