using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class ImmuneFluid : MonoBehaviour
{
    [SerializeField]
    private GameObject fluidArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Competitor") ||
            collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            GameObject go = PhotonNetwork.Instantiate(Path.Combine("Prefabs", fluidArea.name), transform.position, transform.rotation);
            GameManager.Instance.masterPVs.Add(go.GetPhotonView());
        }
    }
    
}
