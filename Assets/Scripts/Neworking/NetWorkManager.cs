using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkManager : MonoBehaviour
{
    public static NetWorkManager Instance;
    /// <summary>Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts.</summary>
    //public bool AutoConnect = true;

    public byte Version = 1;

    public static int PlayerCounter = 0;
    /// <summary>if we don't want to connect in Start(), we have to "remember" if we called ConnectUsingSettings()</summary>
    // private bool ConnectInUpdate = true;
    public GameObject headPrefab;

    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject NetworkPlayer;
    public GameObject Player;
    public GameObject SpawnPoint;
    public GameObject SpawnPoint2;

    public GameObject Platform;
    public GameObject BridgesSpawnPoint1;
    public GameObject BridgesSpawnPoint2;


   // public BridgeSpawner BridgeSpawnerPrefab;

    public GameObject Bridges;
    public GameObject CanonPlace;
    public GameObject CanonPrefab;
    private PhotonView myPhotonView;

    public GameObject Bridge1;
    public GameObject Bridge2;

    public GameObject Bridge3;

    public GameObject BridgeSpawneGroup;

    public Material PlayerMat1;
    public Material PlayerMat2;

    public GameObject SwingSpawn;

    public NetworkSwing NetworkSwing;
    public virtual void Start()
    {
        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);

    }
    public delegate void OnJoinedDeligate(Vector3 pos);
    public OnJoinedDeligate OnJoined;
    //public virtual void Update()
    //{
    //    if (ConnectInUpdate && AutoConnect && !PhotonNetwork.connected)
    //    {
    //        Debug.Log("Update() was called by Unity. Scene is loaded. Let's connect to the Photon Master Server. Calling: PhotonNetwork.ConnectUsingSettings();");

    //        ConnectInUpdate = false;
    //        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
    //    }
    //}


    // below, we implement some callbacks of PUN
    // you can find PUN's callbacks in the class PunBehaviour or in enum PhotonNetworkingMessage


    public virtual void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void OnJoinedRoom()
    {
        PlayerCounter++;
        print(PlayerCounter);
        NetworkSwing.OnJoined();
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.Head.transform.position,
            ViveManager.Instance.Head.transform.rotation, 0);
        PhotonNetwork.Instantiate(LeftHand.name, ViveManager.Instance.LeftHand.transform.position,
        ViveManager.Instance.LeftHand.transform.rotation, 0);
        PhotonNetwork.Instantiate(RightHand.name, ViveManager.Instance.RightHand.transform.position,
     ViveManager.Instance.RightHand.transform.rotation, 0);
        //PhotonNetwork.Instantiate("SwingNetwork", SwingSpawn.transform.position, SwingSpawn.transform.rotation,0);
        print("PhotonNetwork.countOfPlayers:"+ PhotonNetwork.countOfPlayers);
        if (PhotonNetwork.countOfPlayers == 1)
        {
            var p=Instantiate(Player, SpawnPoint.transform.position, Quaternion.identity);
            p.GetComponentInChildren<Renderer>().material =    PlayerMat1;

            var np = PhotonNetwork.Instantiate(NetworkPlayer.name, SpawnPoint.transform.position,
            Quaternion.identity, 0);
            np.GetComponent<Renderer>().material = PlayerMat2;

            ViveManager.Instance.Player = p;
           // Instantiate(BridgeSpawneGroup, BridgesSpawnPoint1.transform.position, BridgesSpawnPoint1.transform.rotation);
            //Instantiate(Bridges, BridgesSpawnPoint1.transform.position, BridgesSpawnPoint1.transform.rotation);
            // PhotonNetwork.Instantiate(BridgeSpawnerPrefab.name, BridgesSpawnPoint2.transform.position,
            //   Quaternion.identity, 0);
            OnJoined(BridgesSpawnPoint1.transform.position);
        }
        else
        {

            var p =Instantiate(Player, SpawnPoint2.transform.position, Quaternion.identity);
            p.GetComponentInChildren<Renderer>().material = PlayerMat2;

            var np =PhotonNetwork.Instantiate(NetworkPlayer.name, SpawnPoint2.transform.position,
            Quaternion.identity, 0);
            np.GetComponent<Renderer>().material = PlayerMat2;
            Instantiate(BridgeSpawneGroup, BridgesSpawnPoint2.transform.position, BridgesSpawnPoint2.transform.rotation);

            ViveManager.Instance.Player = p;
            //Instantiate(Bridges, BridgesSpawnPoint2.transform.position, BridgesSpawnPoint1.transform.rotation);
            //PhotonNetwork.Instantiate(BridgeSpawnerPrefab.name, BridgesSpawnPoint2.transform.position,
            //  Quaternion.identity,0);
            OnJoined(BridgesSpawnPoint1.transform.position);

        }


        //if (PhotonNetwork.playerList.Length==1)
        //{
        //    print("super Duper DJUAJSPDJOUSJAPJPJSAP");
        //    var l = PhotonNetwork.Instantiate(CanonPrefab.name, CanonPlace.transform.position,
        //        CanonPlace.transform.rotation, 0);
        //    l.transform.parent = CanonPlace.transform.parent;
        //}

        //GameObject monster = PhotonNetwork.Instantiate(Platform.name, Vector3.zero, Quaternion.identity, 0);
        //myPhotonView = monster.GetComponent<PhotonView>();

        //   myPhotonView.RPC("MakeReal", PhotonTargets.All);



        //Platforms[] lol = (Platforms[])GameObject.FindObjectsOfType(typeof(Platforms));
        //for (int i = 0; i < lol.Length; i++)
        //{
        //    PhotonNetwork.Instantiate(Platform.name, lol[i].transform.position,
        //        lol[i].transform.rotation, 0);
        //}
    }
}
