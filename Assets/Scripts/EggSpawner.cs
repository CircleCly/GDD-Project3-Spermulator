using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public Transform left;

    public Transform right;

    public GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            Instantiate(egg, left.position, left.rotation);
        } else
        {
            Instantiate(egg, right.position, left.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
