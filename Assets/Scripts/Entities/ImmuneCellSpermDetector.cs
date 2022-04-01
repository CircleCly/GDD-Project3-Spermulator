using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneCellSpermDetector : MonoBehaviour
{
    public bool spermDetected = false;

    public Vector3 spermPosition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Competitor"))
        {
            spermDetected = true;
            spermPosition = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Competitor"))
        {
            spermDetected = false;
        }
    }
}
