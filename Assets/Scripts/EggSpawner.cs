using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public Vector2 upperRight;

    public Vector2 lowerLeft;

    public GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = new Vector2(Random.Range(lowerLeft.x, upperRight.x), Random.Range(lowerLeft.y, upperRight.y));
        Instantiate(egg, pos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
