using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NametagController : MonoBehaviour
{
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.8f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = transform.parent.position + offset;
        transform.rotation = Quaternion.identity;
    }
}
