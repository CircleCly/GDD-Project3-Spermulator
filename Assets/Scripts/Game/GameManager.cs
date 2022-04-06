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
        SceneManager.LoadScene("YouWin");
    }

    public void AltEnding()
    {
        SceneManager.LoadScene("AltEnding");
    }
    #endregion
}