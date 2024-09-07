using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;

    // instance
    public static NetworkManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // connect to the master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("We've connected to the master server.");
    }
}
