using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyControl : MonoBehaviour
{


    // The energy value of this current object
    private float _energy;


    // Max energy of this entity
    public float maxEnergy;

    // Energy decay speed w.r.t to velocity
    public float energyDrain;

    // Energy decay speed w.r.t to velocity
    public float energyDrainRotation;

    // Energy decay speed when not moving
    public float energyDecay;

    // Energy decrement when crashing the wall.
    public float crashEnergyDecrease;

    

    public float Energy { get => _energy; }

    // Start is called before the first frame update
    void Start()
    {
        _energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        ModifyEnergy(-energyDecay * Time.deltaTime);
    }

    public void ModifyEnergy(float amount)
    {
        _energy = Mathf.Clamp(_energy + amount, 0, maxEnergy);
    }
}
