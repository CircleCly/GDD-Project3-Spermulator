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

    [SerializeField]
    [Tooltip("Bacteria motion force")]
    private float _moveForce;

    [SerializeField]
    [Tooltip("Bacteria max speed")]
    private float _maxSpeed;

    [SerializeField]
    [Tooltip("Shoot force")]
    private float _shootForce;

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
        _rb.AddForce(_moveForce * Random.insideUnitCircle);
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxSpeed);
    }

    IEnumerator SpawnAcid()
    {
        while (true)
        {
            GameObject acid = Instantiate(_acid, transform.position, transform.rotation);
            acid.GetComponent<Rigidbody2D>().AddForce(_shootForce * Random.insideUnitCircle);
            yield return new WaitForSeconds(_acidSpawnDelay);
        }
    }

}
