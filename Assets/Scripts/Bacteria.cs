using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The acid that this bacteria generates")]
    private GameObject _acid;

    [SerializeField]
    [Tooltip("Acid spawn time interval")]
    private float _acidSpawnDelay;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnAcid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rb.AddForce(3 * Random.insideUnitCircle);
    }

    IEnumerator SpawnAcid()
    {
        while (true)
        {
            Instantiate(_acid, transform.position, transform.rotation);
            yield return new WaitForSeconds(_acidSpawnDelay);
        }
    }

}
