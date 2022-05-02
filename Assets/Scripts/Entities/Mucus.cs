using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mucus : MonoBehaviour
{
    private AudioSource _as;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _as.Play();
            collision.gameObject.GetComponent<PlayerController>().moveSpeed *= 0.25f;
        }
        else if (collision.gameObject.CompareTag("Competitor"))
        {
            collision.gameObject.GetComponent<CompetitorSpermAI>().moveSpeed *= 0.25f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _as.Play();
            collision.gameObject.GetComponent<PlayerController>().moveSpeed *= 4f;
        }
        else if (collision.gameObject.CompareTag("Competitor"))
        {
            collision.gameObject.GetComponent<CompetitorSpermAI>().moveSpeed *= 4f;
        }
    }
}
