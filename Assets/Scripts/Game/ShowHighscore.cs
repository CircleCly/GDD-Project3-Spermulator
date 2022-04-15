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
        highscoreText.text =
            " Your Distance: " + Math.Round(PlayerPrefs.GetFloat("dist"), 2) + "\n" + 
            " Your Time: " + Math.Round(PlayerPrefs.GetFloat("time"), 2) + "\n" +
            " Shortest Distance: " + Math.Round(PlayerPrefs.GetFloat("minDist"), 2) + " milimeters, \n" + 
            " Shortest Time: " + Math.Round(PlayerPrefs.GetFloat("minTime"), 2) + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHighscore()
    {

    }
}
