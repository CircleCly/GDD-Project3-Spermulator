using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class EggSpawner : MonoBehaviour
{
    public Transform left;

    public Transform right;

    public GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient && Random.Range(0f, 1f) < 0.5f)
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", egg.name), left.position, left.rotation);
        } else
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", egg.name), right.position, right.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
