using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    public Vector2 upperRight;

    public Vector2 lowerLeft;

    public GameObject[] bacteria;

    public int initialCount;

    // Start is called before the first frame update
    void Start() {
        Bacteria.numBacteria = initialCount;
        RandomSpawnBacteria(initialCount);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomSpawnBacteria(int time = 1)
    {
        for (int i = 1; i <= time; i++)
        {
            Vector2 pos = new Vector2(Random.Range(lowerLeft.x, upperRight.x), Random.Range(lowerLeft.y, upperRight.y));
            Instantiate(bacteria[Random.Range(0, bacteria.Length)], pos, transform.rotation);
        }
    }
}
