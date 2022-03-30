using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneCellSpermDetector : MonoBehaviour
{
    public bool spermDetected = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Competitor"))
        {
            spermDetected = true;
        }
    }
}
