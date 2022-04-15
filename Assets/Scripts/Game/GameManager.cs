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

    #region Scene_transitions
    public void StartGame()
    {
        SceneManager.LoadScene("Map");
    }
    public void LoseGame()
    {
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
            if (PlayerPrefs.GetFloat("dist") < PlayerPrefs.GetFloat("minDist"))
            {
                PlayerPrefs.SetFloat("minDist", ctrl.distTravelled);
            }
            else if (PlayerPrefs.GetFloat("time") < PlayerPrefs.GetFloat("minTime"))
            {
                PlayerPrefs.SetFloat("minTime", ctrl.time);
            }
        }
        SceneManager.LoadScene("YouWin");
    }

    public void AltEnding()
    {
        SceneManager.LoadScene("AltEnding");
    }
    #endregion

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("minTime");
        PlayerPrefs.DeleteKey("minDist");
    }
}