using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The acid that this bacteria generates")]
    private GameObject _acid;

    [SerializeField]
    [Tooltip("Bacteria motion force")]
    private float _moveForce;

    [SerializeField]
    [Tooltip("Bacteria max speed")]
    private float _maxSpeed;


    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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

    private void LateUpdate()
    {
        _acid.transform.position = transform.position;
    }

}
