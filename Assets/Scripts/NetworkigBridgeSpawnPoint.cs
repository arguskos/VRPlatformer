using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkigBridgeSpawnPoint : ViveGrip_Grabbable
{

	public int PlayerID;
	public GameObject BridgeSpawner;



	private PhotonView _photonView;

	// Use this for initialization




	public int BridgeID;
	public GameObject Mesh;
	public Material Highlighted;

	private bool _isTouched = false;
	public GameObject Network;

	private float _timer;
	private float _releaseTimer;
	private Rigidbody _rigid;
	private bool _placed = false;
	private float _outTimer;
	private bool _wasBridge;

	private InteractionPlatforms _ghostPlatform;

	public GameObject[] PregabNetworkBridges;


	void Start ()
	{
		_photonView=GetComponent<PhotonView>();
		_rigid=GetComponent<Rigidbody>();
		//s	NetWorkManager.Instance.OnJoinedAction += OnJoinedRoom;
	}
	// somebody is calling this by reflecction maybe? 
	public  void OnJoinedRoom()
	{
		var obj = Instantiate(BridgeSpawner, transform.position, Quaternion.identity);
		obj.GetComponent<BridgeSpawner>().Init(PlayerID, BridgeID);
		obj.transform.parent = transform;
	}
	[PunRPC]
	public void Spawn()
	{
		Destroy(transform.GetChild(0).gameObject);
		//var obj = Instantiate(Bridges[SpawnID], transform.position, transform.rotation);
		//transform.parent = transform;
		_rigid.constraints=RigidbodyConstraints.None;

		GameObject v = PhotonNetwork.Instantiate(PregabNetworkBridges[BridgeID].name, transform.position, transform.rotation, 0);
		v.GetComponent<BridgeNetworkCopy>().ClientBridge = gameObject;

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_photonView.RPC("Spawn", PhotonTargets.AllBufferedViaServer);

		}
		

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
		if (_wasBridge)
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
				PhotonNetwork.Destroy(BridgeSpawner.GetComponentInParent<PhotonView>());

			}
			else
			{
				BridgeSpawner.GetComponent<BridgeSpawner>().Spawn();

			}

		}
		GetComponent<BoxCollider>().isTrigger = true;
		if (_placed)
		{
			GetComponent<Rigidbody>().isKinematic = false;
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
		if (!_placed && _releaseTimer < 0.03 && other.GetComponent<InteractionPlatforms>() && other.GetComponent<InteractionPlatforms>().BridgeID == BridgeID && !Grabbed)
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
		if (_placed && other.GetComponent<InteractionPlatforms>() && other.GetComponent<InteractionPlatforms>().BridgeID == BridgeID)
		{



		}
	}


}
