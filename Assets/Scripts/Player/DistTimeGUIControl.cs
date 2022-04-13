using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DistTimeGUIControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("UI Text for dist travelled.")]
    private TextMeshProUGUI _distText;

    [SerializeField]
    [Tooltip("UI Text for time elapsed")]
    private TextMeshProUGUI _timeText;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distText.text = Math.Round(player.distTravelled) + " mm traveled";
        _timeText.text = Math.Round(player.time) + " seconds elapsed";
    }
}
