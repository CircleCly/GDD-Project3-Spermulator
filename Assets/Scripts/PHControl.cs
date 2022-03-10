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

    // pH decline speed while touching acid
    public float pHAcidDecline;

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
        _pHText.text = "pH: " + Math.Round(_pH, 2);
        if (_pH < minPH || _pH > maxPH)
        {
            Destroy(gameObject);
            GameManager.Instance.LoseGame();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Acid"))
        {
            _pH -= pHAcidDecline * Time.deltaTime;
        }
    }
}
