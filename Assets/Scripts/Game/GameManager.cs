using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public string winnerName = null;

    private bool winnerAnnounced = false;

    private PhotonView _pv;

    #region Unity_functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            PhotonNetwork.Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (winnerName.Length != 0 && !winnerName.Equals(PhotonNetwork.NickName) && !winnerAnnounced)
        {
            LoseGame();
        }
    }
    #endregion

    #region Scene_transitions
    public void StartGame()
    {
        //clearEventSystem();
        PhotonNetwork.LoadLevel("Map");
    }

    public void StartCustomizeSperm()
    {
        //clearEventSystem();
        PhotonNetwork.LoadLevel("CustomizeSpermScene");
    }

    public void StartTutorial()
    {
        //clearEventSystem();
        PhotonNetwork.LoadLevel("TutorialLevel");
    }

    public void EnterLobby()
    {
        //clearEventSystem();
        PhotonNetwork.LoadLevel("WaitingRoom");
    }

    public void LoseGame()
    {
        //clearEventSystem();
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.LoadLevel("YouLose");
        winnerAnnounced = true;
    }
    public void WinGame(PhotonView winnerPv, PlayerController ctrl)
    {
        if (winnerPv.IsMine)
        {
            _pv.RPC("RPC_UpdateWinner", RpcTarget.AllBuffered, winnerPv.Owner.NickName);
        }
        PlayerPrefs.SetFloat("dist", ctrl.distTravelled);
        PlayerPrefs.SetFloat("time", ctrl.time);
        if (!PlayerPrefs.HasKey("minDist") && !PlayerPrefs.HasKey("minTime"))
        {
            PlayerPrefs.SetFloat("minDist", ctrl.distTravelled);
            PlayerPrefs.SetFloat("minTime", ctrl.time);
        }
        else
        {
            if (ctrl.distTravelled < PlayerPrefs.GetFloat("minDist"))
            {
                PlayerPrefs.SetFloat("minDist", ctrl.distTravelled);
            }
            else if (ctrl.time < PlayerPrefs.GetFloat("minTime"))
            {
                PlayerPrefs.SetFloat("minTime", ctrl.time);
            }
        }
        //clearEventSystem();
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.LoadLevel("YouWin");
    }

    [PunRPC]
    public void RPC_UpdateWinner(string whoWon)
    {
        winnerName = whoWon;
    }

    public void AltEnding()
    {
        //clearEventSystem();
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.LoadLevel("AltEnding");
    }
    #endregion

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("minTime");
        PlayerPrefs.DeleteKey("minDist");
    }

    public void QuitToTitle()
    {
        //clearEventSystem();
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("StartMenu");
    }

}