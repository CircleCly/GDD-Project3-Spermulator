using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MPLobbyController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Button hostButton;

    [SerializeField]
    private Button joinButton;

    [SerializeField]
    private Button confirmCodeButton;

    [SerializeField]
    private InputField code;

    [SerializeField]
    private int roomSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        hostButton.interactable = true;
        joinButton.interactable = true;
    }

    public void CreateRoom()
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room " + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room ... trying again");
        CreateRoom();
    }

    public void JoinRoom()
    {
        Debug.Log("Joining room now");
        int roomNum = int.Parse(code.text);
        PhotonNetwork.JoinRoom("Room " + roomNum);
        Debug.Log("Trying to join room " + roomNum);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("That room does not exist");
    }

    public override void OnJoinedRoom()
    {
        GameManager.Instance.EnterLobby();
    }
}
