using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Egg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.WinGame(collision.gameObject.GetComponent<PhotonView>(), collision.gameObject.GetComponent<PlayerController>());
        } else if (collision.gameObject.CompareTag("Competitor"))
        {
            GameManager.Instance.LoseGame();
        }
    }
}
