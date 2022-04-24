using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    public float amplitude;

    public float period;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WiggleCoroutine(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WiggleCoroutine(float period)
    {
        float time = 0;
        float initialZ = transform.rotation.eulerAngles.z;
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 0, initialZ + amplitude * Mathf.Sin(6.28f / period * time));
            time += Time.deltaTime;
            yield return null;
        }
    }
}
