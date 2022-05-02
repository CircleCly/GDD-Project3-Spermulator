using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SPLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject tutorialPopup;

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
        Debug.Log("Room created");
        Debug.Log("Room joined");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room!");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("You are now in a room.");
        tutorialPopup.SetActive(true);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.OfflineMode = true;
        CreateSingleplayerRoom();
    }

    public void EnableOfflineMode()
    {
        Debug.Log("Offline mode enabled");
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.OfflineMode = true;
            CreateSingleplayerRoom();
            return;
        }
        Debug.Log("Trying to disconnect");
        PhotonNetwork.Disconnect();
    }


    public void DisableOfflineMode()
    {
        PhotonNetwork.OfflineMode = false;
    }
}
