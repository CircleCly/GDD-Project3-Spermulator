using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    public GameObject singlePlayer, multiplayer;
    public GameObject mpPopup;
    public GameObject tutorialPopup;
    public GameObject enterCodePopup;


    public void ShowPlayerModes()
    {
        singlePlayer.SetActive(true);
        multiplayer.SetActive(true);
    }

    public void ShowTutorialPopup()
    {
        tutorialPopup.SetActive(true);
    }

    public void ShowMultiplayerPopup()
    {
        mpPopup.SetActive(true);
    }

    public void ShowEnterCodePopup()
    {
        enterCodePopup.SetActive(true);
    }
}
