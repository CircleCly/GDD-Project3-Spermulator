using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class EntitySpawner : MonoBehaviour
{
    public EntitySpawnData[] entitySpawnData;

    // Start is called before the first frame update
    void Start() {
        if (PhotonNetwork.IsMasterClient)
        {
            Bacteria.numBacteria = entitySpawnData[0].initialCount;
            for (int i = 0; i < 2; i++)
            {
                RandomSpawnEntity(entitySpawnData[i]);
            }
            if (PhotonNetwork.OfflineMode)
            {
                SpawnCompetitorSperm(entitySpawnData[2]);
            }
        }
    }

    private void RandomSpawnEntity(EntitySpawnData esd)
    {
        Bounds b = esd.spawnArea.bounds;
        for (int i = 1; i <= esd.initialCount; i++)
        {
            Vector2 pos = new Vector2(
                Random.Range(b.min.x, b.max.x),
                Random.Range(b.min.y, b.max.y)
            );
            GameObject g = PhotonNetwork.InstantiateRoomObject(Path.Combine("Prefabs", esd.entity.name), pos, transform.rotation);
            GameManager.Instance.masterPVs.Add(g.GetComponent<PhotonView>());
        }
    }

    private void SpawnCompetitorSperm(EntitySpawnData esd)
    {
        Bounds b = esd.spawnArea.bounds;
        for (int i = 1; i <= esd.initialCount; i++)
        {
            Vector2 pos = new Vector2(
                Random.Range(b.min.x, b.max.x),
                Random.Range(b.min.y, b.max.y)
            );
            GameObject competitor = PhotonNetwork.InstantiateRoomObject(Path.Combine("Prefabs", esd.entity.name), pos, transform.rotation);
            CompetitorSpermAI ai = competitor.GetComponent<CompetitorSpermAI>();
            ai.evasionImportance = Random.Range(0.4f, 0.7f);
            ai.moveSpeed = Random.Range(2.2f, 3f);
            ai.rotationSpeed = Random.Range(15f, 20f);
            ai.firstWaypoint = GameObject.Find("WP0");
            Color c = Color.HSVToRGB(Random.Range(0f, 1f), 0.6f, 0.8f);
            ai.c = c;
            GameManager.Instance.masterPVs.Add(competitor.GetComponent<PhotonView>());
        }
    }
}
