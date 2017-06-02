using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class NetworkBeidgeSpawnerSpawner : MonoBehaviour {

    // Use this for initialization
    public int SpawnID;

    public GameObject BridgeSpawner;
    private bool _created = false;
	void Start () {
		print("WAKKWA");
			
	}
	public void OnJoined(int id)
    {
		if (!_created)
		{
			var obj = Instantiate(BridgeSpawner, transform.position, Quaternion.identity);
			obj.GetComponent<BridgeSpawner>().Init(id, SpawnID);
			obj.transform.parent = transform;
			_created = true;
		}
	}

	public void Awake()
	{
		//NetWorkManager.Instance.OnJoined += OnJoined;
		OnJoined(2);
	}

	
    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
		    OnJoined(2);

	    }
	}
}
