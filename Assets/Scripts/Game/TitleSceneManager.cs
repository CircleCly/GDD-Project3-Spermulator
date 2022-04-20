using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    public GameObject singlePlayer, multiplayer;
    public GameObject popup;


    public void ShowPlayerModes()
    {
        singlePlayer.SetActive(true);
        multiplayer.SetActive(true);
    }

    public void ShowPopup()
    {
        popup.SetActive(true);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void StartTutorial()
    {
        GameManager.Instance.StartTutorial();
    }
}
