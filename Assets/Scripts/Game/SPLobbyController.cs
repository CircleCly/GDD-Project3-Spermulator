using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SPLobbyController : MonoBehaviourPunCallbacks
{
    public GameObject tutorialPopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateSingleplayerRoom()
    {
        Debug.Log("Started Singleplayer Game");
        PhotonNetwork.NickName = "Player";
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 1 };
        PhotonNetwork.CreateRoom("Room " + randomRoomNumber, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("You are now in a room.");
        tutorialPopup.SetActive(true);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.OfflineMode = true;
    }

    public void EnableOfflineMode()
    {
        Debug.Log("Offline mode enabled");
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.OfflineMode = true;
            return;
        }
        PhotonNetwork.Disconnect();
    }


    public void DisableOfflineMode()
    {
        PhotonNetwork.OfflineMode = false;
    }
}
