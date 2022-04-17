using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject pHUI;
    public GameObject energyUI;
    public GameObject timeDistUI;

    private PHControl _playerPHControl;

    private EnergyControl _playerEnergyControl;

    // Start is called before the first frame update
    void Start()
    {
        pHUI.SetActive(false);
        energyUI.SetActive(false);
        timeDistUI.SetActive(false);
        _playerPHControl = gameObject.GetComponent<PHControl>();
        _playerPHControl.pHDecay = 0;
        _playerEnergyControl = gameObject.GetComponent<EnergyControl>();
        _playerEnergyControl.energyDecay = _playerEnergyControl.energyDrain
            = _playerEnergyControl.energyDrainRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _playerPHControl.PH = Mathf.Clamp(_playerPHControl.PH, _playerPHControl.minPH + 0.05f, _playerPHControl.maxPH - 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShowPH"))
        {
            pHUI.SetActive(true);
            _playerPHControl.pHDecay = 0.01f;
        }
        else if (collision.gameObject.CompareTag("ShowEnergy"))
        {
            energyUI.SetActive(true);
            _playerEnergyControl.energyDrain = 0.005f; 
            _playerEnergyControl.energyDrainRotation = 0.01f;
            _playerEnergyControl.energyDecay = 2f;
        }
    }
}
