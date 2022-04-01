using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public EntitySpawnData[] entitySpawnData;

    // Start is called before the first frame update
    void Start() {
        Bacteria.numBacteria = entitySpawnData[0].initialCount;
        foreach (var esd in entitySpawnData) {
            RandomSpawnEntity(esd);
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
            Instantiate(esd.entity, pos, transform.rotation);
        }
    }
}
