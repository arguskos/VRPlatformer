using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBridges : ViveGrip_Grabbable {
    public int BridgeID;
    public GameObject Mesh;
    private Queue<Color> oldColors = new Queue<Color>();
    Color tintColor = Color.white;
    public Material Highlighted;
    float tintRatio = 111110.2f;
        
    private bool _isTouched=false;
    public GameObject Network;
    public BridgeSpawner BridgeSpawner;
    // Use this for initialization
    void Start () {
        Mesh=transform.GetChild(0).gameObject;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        foreach (Renderer t in Mesh.GetComponentsInChildren<Renderer>())
        {
            t.enabled = false;
        }

    }
    private void Update()
    {
       
    }


    void ViveGripGrabStart(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = true;
        if (!_isTouched)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            foreach (Renderer t in Mesh.GetComponentsInChildren<Renderer>())
            {
                t.enabled = false;
            }
            _isTouched = true;
            Network.SetActive(true);
            BridgeSpawner.Spawn();
            GetComponent<ViveGrip_Highlighter>().RemoveHighlight();
        }
        GetComponent<BoxCollider>().isTrigger = true;
    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = false;
        GetComponent<BoxCollider>().isTrigger = false;

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<InteractionPlatforms>()&& other.GetComponent<InteractionPlatforms>().BridgeID==BridgeID&& !Grabbed)
        {
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            gameObject.SetActive(false);
            other.GetComponent<InteractionPlatforms>().MyPhotonView.RPC("MakeReal", PhotonTargets.All);
        }
    }
}
