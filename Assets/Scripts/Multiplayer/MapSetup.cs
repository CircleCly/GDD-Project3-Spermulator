using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class MapSetup : MonoBehaviour
{
    public BoxCollider2D startArea;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Bounds b = startArea.bounds;
        Debug.Log("Creating Player");
        Vector2 pos = new Vector2(
                Random.Range(b.min.x, b.max.x),
                Random.Range(b.min.y, b.max.y)
        );
        PhotonNetwork.Instantiate(
            Path.Combine("Prefabs", "Player"), pos, Quaternion.identity);
        //PhotonNetwork.Instantiate(
            //Path.Combine("Prefabs", "GameManager"), Vector3.zero, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
