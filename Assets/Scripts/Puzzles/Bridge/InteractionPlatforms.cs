﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlatforms : MonoBehaviour {

	

    private bool _isGhost;
    private float _decayTimer;
    public float DecayTime = 4;
    public float ShakeStrength = 1;
    public float ShakeTime = 3;
    private Vector3 _initPosition;
    [HideInInspector]
    public PhotonView MyPhotonView;

    private int _clicks;
    public Platforms Platform;
    public int BridgeID;
    // Use this for initialization
    void Start()
    {
        _isGhost = true;
        _initPosition = transform.position;
        GetComponent<BoxCollider>().isTrigger = true;
        MyPhotonView = GetComponent<PhotonView>();
    }
    void ViveGripInteractionStart(ViveGrip_GripPoint gripPoint)
    {
        MyPhotonView.RPC("MakeReal", PhotonTargets.All);
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    MyPhotonView.RPC("MakeGhost", PhotonTargets.All);

        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    MyPhotonView.RPC("MakeReal", PhotonTargets.All);

        //  }
            //if (_decayTimer > 0)
            //{
            //    _decayTimer -= Time.deltaTime;
            //    if (_decayTimer < ShakeTime)
            //    {
            //        //   transform.position = new Vector3(transform.position.x+ Mathf.Sin(Time.time * 0.1f), transform.position.y+ Mathf.Sin(Time.time * 0.1f), transform.position.z+ Mathf.Sin(Time.time * 0.1f));
            //        transform.position = new Vector3(_initPosition.x + Mathf.Sin(ShakeStrength * Random.Range(-Time.time, Time.time)) * 0.02f, _initPosition.y + Mathf.Sin(ShakeStrength * Random.Range(-Time.time, Time.time)) * 0.02f, _initPosition.z + Mathf.Sin(ShakeStrength * Random.Range(-Time.time, Time.time)) * 0.02f);

            //    }
            //    if (_decayTimer <= 0)
            //    {
            //        _decayTimer = 0;
            //        // GameObject n= Instantiate(this.gameObject);
            //        //n.transform.position = transform.position;
            //        //n.GetComponent<Platforms>().MakeGhost();    
            //        Platform.MakeGhost();
            //        //BreakPlatform();
            //        //transform.position = _initPosition;
            //    }
            //}
        }



    //Counts how many times this platform has been clicked
    public void Click()
    {
        _clicks++;
        if (_clicks == 1)
        {
            MakeReal();
        }
        else if (_clicks == 2)
        {
           // BreakPlatform();
        }
    }



    [PunRPC]
    public void MakeReal()
    {

        _isGhost = false;
        _decayTimer = DecayTime;
        GetComponent<BoxCollider>().isTrigger = false;

        //GetComponent<BoxCollider>().isTrigger = false;
        Platform.MakeReal();

    }


    [PunRPC]
    public void MakeGhost()
    {

        _isGhost =true;
        GetComponent<BoxCollider>().isTrigger = true;

        //GetComponent<BoxCollider>().isTrigger = false;
        Platform.MakeGhost();

    }
    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,        // Old school alpha-blending mode, fresnel does not affect amount of transparency
        Transparent // Physically plausible transparency mode, implemented as alpha pre-multiply
    }

    public void SetupMaterialWithBlendMode(Material material, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                material.SetOverrideTag("RenderType", "");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                material.SetOverrideTag("RenderType", "TransparentCutout");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }
    //Enables collision with ground and changes to pulsating
    ////TODO: over time decay with a transparency fade
    //[PunRPC]
    //public void BreakPlatform()
    //{

    //    _isGhost = true;

    //    for (int i = 0; i < _platformParts.Length; ++i)
    //    {
    //        _platformParts[i].GetComponent<Renderer>().material = Mat;
    //        var m = _platformParts[i].GetComponent<Renderer>().material;

    //        SetupMaterialWithBlendMode(m, BlendMode.Transparent);
    //        m.color = new Color(m.color.r, m.color.g, m.color.b, 0.5f);
    //        _platformParts[i].GetComponent<Pulsating>().enabled = true;
    //        _platformParts[i].GetComponent<Collider>().enabled = true;
    //        _platformParts[i].GetComponent<Rigidbody>().useGravity = true;
    //        _platformParts[i].GetComponent<PlatformPart>().IgnoreCollision = true;
    //    }

    //    GetComponent<BoxCollider>().isTrigger = false;
    //    StartCoroutine(DestroyWithTime());
    //}

    public IEnumerator DestroyWithTime()
    {
        yield return new WaitForSeconds(1);
        //Destroy(this.gameObject);
    }
 
}
