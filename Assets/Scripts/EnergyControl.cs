using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("UI Text for Energy")]
    private TextMeshProUGUI _energyText;

    // The energy value of this current object
    private float _energy;

    // Cached player rigidbody
    private Rigidbody2D _rb;

    // Max energy of this entity
    public float maxEnergy;

    // Energy decay speed w.r.t to velocity
    public float energyDrain;

    // Energy decay speed when not moving
    public float energyDecay;

    public float Energy { get => _energy; set => _energy = value; }

    // Start is called before the first frame update
    void Start()
    {
        _energy = maxEnergy;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _energy -= Mathf.Clamp(_rb.velocity.magnitude * energyDrain + energyDecay, 0, maxEnergy);
        _energyText.text = "Energy: " + Math.Round(_energy) + " eV";
    }
}
