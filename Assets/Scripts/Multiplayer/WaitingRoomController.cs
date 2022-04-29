using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitingRoomController : MonoBehaviourPunCallbacks
{
    private PhotonView myPhotonView;

    private int playerCount;
    private int roomSize;

    [SerializeField]
    private int minPlayersToStart;

    [SerializeField]
    private Text roomCountDisplay, timerToStartDisplay, title, nameDisplay;

    [SerializeField]
    private GameObject duplicateNameError;

    [SerializeField]
    private InputField nameInput;

    private bool readyToCountdown;
    private bool readyToStart;
    private bool startingGame;

    private float timerToStartGame;
    private float notFullGameTimer;
    private float fullGameTimer;

    [SerializeField]
    private float maxWaitTime;

    [SerializeField]
    private float maxFullGameWaitTime;

    private void Start()
    {
        myPhotonView = GetComponent<PhotonView>();
        fullGameTimer = maxFullGameWaitTime;
        notFullGameTimer = maxWaitTime;
        timerToStartGame = maxWaitTime;
        title.text = PhotonNetwork.CurrentRoom.Name;
        PlayerCountUpdate();
        PhotonNetwork.LocalPlayer.NickName = "Player " + playerCount;
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        roomCountDisplay.text = playerCount + "/" + roomSize;

        if (playerCount == roomSize)
        {
            readyToStart = true;
        }
        else if (playerCount >= minPlayersToStart)
        {
            readyToCountdown = true;
        }
        else
        {
            readyToCountdown = false;
            readyToStart = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        title.text = PhotonNetwork.CurrentRoom.Name;
        PlayerCountUpdate();
        if (PhotonNetwork.IsMasterClient)
        {
            myPhotonView.RPC("RPC_SendTimer", RpcTarget.Others, timerToStartGame);
        }
    }

    [PunRPC]
    private void RPC_SendTimer(float timeIn)
    {
        timerToStartGame = timeIn;
        notFullGameTimer = timeIn;
        if (timeIn < fullGameTimer)
        {
            fullGameTimer = timeIn;
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerCountUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        WaitingForMorePlayers();
        nameDisplay.text = "Your name: " + PhotonNetwork.LocalPlayer.NickName;
    }

    void WaitingForMorePlayers()
    {
        if (playerCount <= 1)
        {
            ResetTimer();
        }

        if (readyToStart)
        {
            fullGameTimer -= Time.deltaTime;
            timerToStartGame = fullGameTimer;
        }
        else if (readyToCountdown)
        {
            notFullGameTimer -= Time.deltaTime;
            timerToStartGame = notFullGameTimer;
        }
        string tempTimer = string.Format("{0:00}", timerToStartGame);
        timerToStartDisplay.text = tempTimer;
        if (timerToStartGame <= 0f)
        {
            if (startingGame)
                return;
            StartGame();
        }
    }

    void ResetTimer()
    {
        timerToStartGame = maxWaitTime;
        notFullGameTimer = maxWaitTime;
        fullGameTimer = maxFullGameWaitTime;
    }

    void StartGame()
    {
        startingGame = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel("Map");
    }

    public void DelayCancel()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void ChangeName()
    {
        foreach (var p in PhotonNetwork.PlayerList)
        {
            if (!p.IsLocal && p.NickName.Equals(nameInput.text))
            {
                duplicateNameError.SetActive(true);
                return;
            }
        }
        PhotonNetwork.LocalPlayer.NickName = nameInput.text;
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("StartMenu");
    }
}
