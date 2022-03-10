using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    public Vector2 upperRight;

    public Vector2 lowerLeft;

    public float spawnTimeMin;

    public float spawnTimeMax;

    public GameObject[] bacteria;

    public int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 1; i <= spawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
            Vector2 pos = new Vector2(Random.Range(lowerLeft.x, upperRight.x), Random.Range(lowerLeft.y, upperRight.y));
            Instantiate(bacteria[Random.Range(0, bacteria.Length)], pos, transform.rotation);
        }
    }
}
