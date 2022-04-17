using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    public GameObject popup;

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
