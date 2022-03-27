using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PHGUIControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("UI Text for pH")]
    private TextMeshProUGUI _pHText;

    [SerializeField]
    [Tooltip("Marker for pH")]
    private Image _pHMarker;

    [SerializeField]
    [Tooltip("Marker sliding range")]
    private Vector2 _markerRange;

    public PHControl pHControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pH = pHControl.PH;
        float minPH = pHControl.minPH;
        float maxPH = pHControl.maxPH;
        _pHText.text = "" + Math.Round(pH, 2);
        float pHProportion = (pH - minPH) / (maxPH - minPH);
        float newX = pHProportion * (_markerRange.y - _markerRange.x) + _markerRange.x;
        _pHMarker.rectTransform.anchoredPosition = new Vector2(newX, _pHMarker.rectTransform.anchoredPosition.y);
        if (pH < minPH + (maxPH - minPH) * 0.2)
        {
            _pHText.color = Color.red;
        }
        else
        {
            _pHText.color = Color.white;
        }
    }
}
