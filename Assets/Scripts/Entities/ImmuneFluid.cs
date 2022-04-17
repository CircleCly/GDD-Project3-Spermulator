using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneFluid : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Basic area generated on contact")]
    private GameObject _basicArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Competitor") ||
            collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Instantiate(_basicArea, transform.position, transform.rotation);
        }
    }
    
}
