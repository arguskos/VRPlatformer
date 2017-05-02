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

    private bool _isTouched;
    // Use this for initialization
    void Start () {
        Mesh=transform.GetChild(0).gameObject;

        foreach (Renderer t in Mesh.GetComponentsInChildren<Renderer>())
        {
            t.enabled = false; 
        }

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
        }

    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = false;

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
