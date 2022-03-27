using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PHControl : MonoBehaviour
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

    // Cached Rigidbody component.
    private Rigidbody2D _rb;

    // The pH value of this current object
    private float _pH;

    // Minimum for the entity to survive
    public float minPH;

    // Maximum for the entity to survive
    public float maxPH;

    // pH decline speed, per second
    public float pHDecay;

    public float PH { get => _pH; set => _pH = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pH = maxPH;
    }

    // Update is called once per frame
    void Update()
    {
        _pH -= pHDecay * Time.deltaTime;
        _pHText.text = "" + Math.Round(_pH, 2);
        float pHProportion = (_pH - minPH) / (maxPH - minPH);
        float newX = pHProportion * (_markerRange.y - _markerRange.x) + _markerRange.x;
        _pHMarker.rectTransform.anchoredPosition = new Vector2(newX, _pHMarker.rectTransform.anchoredPosition.y);

        if (_pH < minPH + (maxPH - minPH) * 0.2)
        {
            _pHText.color = Color.red;
        } else
        {
            _pHText.color = Color.white;
        }
        
        if (_pH < minPH || _pH > maxPH)
        {
            GameManager.Instance.LoseGame();
        }
    }

   
}
