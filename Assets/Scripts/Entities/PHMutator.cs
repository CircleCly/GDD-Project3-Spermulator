using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHMutator : MonoBehaviour
{
    // pH decline speed while touching acid
    public float pHAcidDecline;

    public float stickyness;

    // Energy decline speed while touching acid
    public float energyDrain;

    private GameObject _player;

    private PHControl _playerPHCtrl;

    private Rigidbody2D _playerRb;

    private EnergyControl _playerEnergy;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerPHCtrl = _player.GetComponent<PHControl>();
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerEnergy = _player.GetComponent<EnergyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_player == null)
            {
                _player = gameObject;
                _playerPHCtrl = _player.GetComponent<PHControl>();
                _playerRb = _player.GetComponent<Rigidbody2D>();
                _playerEnergy = _player.GetComponent<EnergyControl>();
            } else
            {
                _playerPHCtrl.PH -= pHAcidDecline * Time.deltaTime;
                _playerRb.AddForce(-stickyness * _playerRb.velocity);
                _playerEnergy.ModifyEnergy(-energyDrain * Time.deltaTime);
            }
        } else if (collision.gameObject.CompareTag("Competitor")) {
            PHControl phControl = collision.gameObject.GetComponent<PHControl>();
            EnergyControl energyControl = collision.gameObject.GetComponent<EnergyControl>();
            phControl.PH -= pHAcidDecline * Time.deltaTime;
            energyControl.ModifyEnergy(-pHAcidDecline * Time.deltaTime);
        }
    }
}
