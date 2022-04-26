using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance = null;

    #region Unity_functions
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
    }
    #endregion

    void clearEventSystem()
    {
        GameObject es = GameObject.Find("EventSystem");
        if (es != null)
        {
            Destroy(es);
        }
    }

    #region Scene_transitions
    public void StartGame()
    {
        clearEventSystem();
        SceneManager.LoadScene("Map");
    }

    public void StartSingleplayerGame()
    {
        Debug.Log("Started Singleplayer Game");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 1};
        PhotonNetwork.CreateRoom("Room " + randomRoomNumber, roomOps);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.OfflineMode)
        {
            Debug.Log("You are now in a room.");
            SceneManager.LoadScene("Map");
        }
    }

    public void EnableOfflineMode()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.OfflineMode = true;
            return;
        }
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.OfflineMode = true;
    }

    public void DisableOfflineMode()
    {
        PhotonNetwork.OfflineMode = false;
    }

    public void StartCustomizeSperm()
    {
        clearEventSystem();
        SceneManager.LoadScene("CustomizeSpermScene");
    }

    public void StartTutorial()
    {
        clearEventSystem();
        SceneManager.LoadScene("TutorialLevel");
    }

    public void EnterLobby()
    {
        clearEventSystem();
        SceneManager.LoadScene("WaitingRoom");
    }

    public void LoseGame()
    {
        clearEventSystem();
        SceneManager.LoadScene("YouLose");
    }
    public void WinGame(PlayerController ctrl)
    {
        PlayerPrefs.SetFloat("dist", ctrl.distTravelled);
        PlayerPrefs.SetFloat("time", ctrl.time);
        if (!PlayerPrefs.HasKey("minDist"))
        {
            PlayerPrefs.SetFloat("minDist", ctrl.distTravelled);
        }
        if (!PlayerPrefs.HasKey("minTime"))
        {
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
        clearEventSystem();
        SceneManager.LoadScene("YouWin");
    }

    public void AltEnding()
    {
        clearEventSystem();
        SceneManager.LoadScene("AltEnding");
    }
    #endregion

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("minTime");
        PlayerPrefs.DeleteKey("minDist");
    }
}