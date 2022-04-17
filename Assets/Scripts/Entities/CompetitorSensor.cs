using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorSensor : MonoBehaviour
{
    public bool acidDetected = false;
    public Vector3 acidPosition;

    public bool baseDetected = false;
    public Vector3 basePosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Acid"))
        {
            acidDetected = true;
            acidPosition = collision.gameObject.transform.position;
        }
        else if (collision.gameObject.CompareTag("Base"))
        {
            baseDetected = true;
            basePosition = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Acid"))
        {

            acidDetected = true;
            acidPosition = collision.gameObject.transform.position;
        }
        else if (collision.gameObject.CompareTag("Base"))
        {
            baseDetected = true;
            basePosition = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Acid"))
        {
            acidDetected = false;
        }
        else if (collision.gameObject.CompareTag("Base"))
        {
            baseDetected = false;
        }
    }
}
