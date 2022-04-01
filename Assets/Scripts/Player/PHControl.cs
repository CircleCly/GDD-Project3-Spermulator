using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PHControl : MonoBehaviour
{
    // The pH value of this current object
    private float _pH;

    // Minimum for the entity to survive
    public float minPH;

    // Start value for this entity;
    public float startPH;

    // Maximum for the entity to survive
    public float maxPH;

    // pH decline speed, per second
    public float pHDecay;

    // pH decline when crashing
    public float crashPHDecrease;

    public float PH { get => _pH; set => _pH = value; }

    // Start is called before the first frame update
    void Start()
    {
        _pH = startPH;
    }

    // Update is called once per frame
    void Update()
    {
        _pH -= pHDecay * Time.deltaTime;
        
        if (_pH < minPH || _pH > maxPH)
        {
            GameManager.Instance.LoseGame();
        }
    }

   
}
