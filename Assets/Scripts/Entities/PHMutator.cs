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

    private AudioSource _as;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PHControl _playerPHCtrl = collision.gameObject.GetComponent<PHControl>();
            Rigidbody2D _playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            EnergyControl _playerEnergy = collision.gameObject.GetComponent<EnergyControl>();
            _playerPHCtrl.PH -= pHAcidDecline * Time.deltaTime;
            _playerRb.AddForce(-stickyness * _playerRb.velocity);
            _playerEnergy.ModifyEnergy(-energyDrain * Time.deltaTime);
            
        } else if (collision.gameObject.CompareTag("Competitor")) {
            PHControl phControl = collision.gameObject.GetComponent<PHControl>();
            EnergyControl energyControl = collision.gameObject.GetComponent<EnergyControl>();
            phControl.PH -= pHAcidDecline * Time.deltaTime;
            energyControl.ModifyEnergy(-pHAcidDecline * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_as.isPlaying)
            {
                _as.Play();
            }
        }
    }
}
