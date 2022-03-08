using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHControl : MonoBehaviour
{
    // The pH value of this current object
    private float _pH;

    // Minimum for the entity to survive
    public float minPH;

    // Maximum for the entity to survive
    public float maxPH;

    public float PH { get => _pH; set => _pH = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_pH < minPH || _pH > maxPH)
        {
            Destroy(gameObject);
        }
    }
}
