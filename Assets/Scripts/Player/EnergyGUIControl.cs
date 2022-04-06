using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class EnergyGUIControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("UI Text for Energy")]
    private TextMeshProUGUI _energyText;

    [SerializeField]
    [Tooltip("Slider for Energy")]
    private Image _energySlider;

    public EnergyControl energyControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float energy = energyControl.Energy;
        float maxEnergy = energyControl.maxEnergy;
        _energyText.text = Math.Round(energy) + " eV";
        _energySlider.rectTransform.localScale = new Vector3(energy / maxEnergy, _energySlider.rectTransform.localScale.y, 0);
    }
}
