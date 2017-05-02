using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgesInstances : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> BrifgeType1;
    public List<GameObject> BrifgeType2;
    public List<GameObject> BrifgeType3;

    public static BridgesInstances Instance;

    public GameObject Bridge1;
    public GameObject Bridge2;
    public GameObject Bridge3;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        foreach (Transform bridge in transform)
        {
            switch (bridge.GetComponent<PlayerBridges>().BridgeID)
            {
                case 0:
                    BrifgeType1.Add(bridge.gameObject);
                    break;
                case 1:
                    BrifgeType2.Add(bridge.gameObject);
                    break;
                case 2:
                    BrifgeType3.Add(bridge.gameObject);
                    break;
            }

        }



        foreach (var bridge in BridgesInstances.Instance.BrifgeType1)
        {
            PhotonNetwork.Instantiate(Bridge1.name, bridge.transform.position, bridge.transform.rotation, 0);
        }

        foreach (var bridge in BridgesInstances.Instance.BrifgeType2)
        {
            PhotonNetwork.Instantiate(Bridge2.name, bridge.transform.position, bridge.transform.rotation, 0);
        }
        foreach (var bridge in BridgesInstances.Instance.BrifgeType3)
        {
            print("DOING SSOMETEIN");
            PhotonNetwork.Instantiate(Bridge3.name, bridge.transform.position, bridge.transform.rotation, 0);
        }

    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.B)
    //    {
    //        Instance()
    //    }
    //}
    void OnDestroy()
    {
        if (Instance == null)
            Instance = null;

    }
}
