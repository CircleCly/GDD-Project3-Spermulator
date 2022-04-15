using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShowHighscore : MonoBehaviour
{
    public Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        highscoreText.text =
            " Your Distance: " + Math.Round(PlayerPrefs.GetFloat("dist"), 2) + " millimeters\n" +
            " Your Time: " + Math.Round(PlayerPrefs.GetFloat("time"), 2) + " seconds \n" +
            " Shortest Distance: " + Math.Round(PlayerPrefs.GetFloat("minDist"), 2) + " millimeters, \n" +
            " Shortest Time: " + Math.Round(PlayerPrefs.GetFloat("minTime"), 2) + " seconds";
    }
}
