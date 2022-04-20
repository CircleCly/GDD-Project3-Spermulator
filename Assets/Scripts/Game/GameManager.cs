using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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
        if (SceneManager.GetActiveScene().name == "Map" && GameObject.FindWithTag("Player") == null)
        {
            LoseGame();
        }
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
        SceneManager.LoadScene("Lobby");
    }

    public void LoseGame()
    {
        clearEventSystem();
        SceneManager.LoadScene("YouLose");
    }
    public void WinGame()
    {
        PlayerController ctrl = GameObject.Find("Player").GetComponent<PlayerController>();
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