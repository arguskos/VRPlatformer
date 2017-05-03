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

    private float _timer;
    private float _releaseTimer;
    private Rigidbody _rigid;
    private bool _placed = false;
    private float _outTimer;
    private bool _wasBridge;

    private InteractionPlatforms _ghostPlatform;
    // Use this for initialization
    void Start () {
        Mesh=transform.GetChild(0).gameObject;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Hide();
        _rigid = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (!GameFlow.IsBridgeReplacement)
        {
            if (_isTouched && !Grabbed)
            {
                _timer += Time.deltaTime;
                if (_timer > 5)
                {
                    PhotonNetwork.Destroy(Network);
                    Destroy(this.gameObject);
                }
            }
        }
        if (!Grabbed)
        {
            _releaseTimer += Time.deltaTime;
        }
        if(_wasBridge)
        {
            
            _outTimer -= Time.deltaTime;
           
                if (_outTimer < 0)
                {
                    _outTimer = 0;
                    _wasBridge = false;
                    _placed = false;
                }
           
        }
    }


    void ViveGripGrabStart(ViveGrip_GripPoint gripPoint)
    {
        _releaseTimer = 0;
        Grabbed = true;
        _timer = 0;
        if (!_isTouched)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            foreach (Renderer t in Mesh.GetComponentsInChildren<Renderer>())
            {
                t.enabled = false;
            }
            _isTouched = true;
            Network.SetActive(true);
            if (GameFlow.IsBridgeReplacement)
            {
                Destroy(BridgeSpawner.gameObject);

            }
            else
            {
                BridgeSpawner.GetComponent<BridgeSpawner>().Spawn();

            }

        }
        GetComponent<BoxCollider>().isTrigger = true;
        if(_placed)
        {
            GetComponent<Rigidbody>().isKinematic =false;
           Show();
            _ghostPlatform.GetComponent<InteractionPlatforms>().MyPhotonView.RPC("MakeGhost", PhotonTargets.All);
            _placed = false;

        }
    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = false;
        GetComponent<BoxCollider>().isTrigger = false;

    }

    public void Hide()
    {
        foreach (Renderer t in Mesh.GetComponentsInChildren<Renderer>())
        {
            t.enabled = false;
        }
    }

    public void Show()
    {
        foreach (Renderer t in Mesh.GetComponentsInChildren<Renderer>())
        {
            t.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!_placed &&_releaseTimer<0.03 &&other.GetComponent<InteractionPlatforms>()&& other.GetComponent<InteractionPlatforms>().BridgeID==BridgeID&& !Grabbed)
        {
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            if (!GameFlow.IsBridgeReplacement)
            {
                gameObject.SetActive(false);


            }

            Hide();
            print("LOL");
            _rigid.isKinematic = true;
            other.GetComponent<InteractionPlatforms>().MyPhotonView.RPC("MakeReal", PhotonTargets.All);
            //other.gameObject.SetActive(false);
            //GetComponent<BoxCollider>().isTrigger = false;

            _ghostPlatform = other.GetComponent<InteractionPlatforms>();
            _placed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_placed && other.GetComponent<InteractionPlatforms>() && other.GetComponent<InteractionPlatforms>().BridgeID == BridgeID )
        {

            

        }
    }
}
