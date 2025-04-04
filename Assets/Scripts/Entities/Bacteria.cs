using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

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

    [SerializeField]
    [Tooltip("Replicate period in seconds")]
    private float _initialReplicatePeriod;

    [SerializeField]
    [Tooltip("Max number of bacterias on screen")]
    private int _maxBacteriaCount;

    [SerializeField]
    [Tooltip("Bacteria Mean Lifespan")]
    private float _meanLifeSpan;

    private Rigidbody2D _rb;

    private PhotonView _pv;

    public static int numBacteria = 0;


    private float _lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        _lifeSpan = Random.Range(0.7f, 1.3f) * _meanLifeSpan;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ReplicateCoroutine());
        StartCoroutine(DeathTimer());
        _pv = GetComponentInParent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _rb.AddForce(_moveForce * Random.insideUnitCircle);
            _rb.linearVelocity = Vector2.ClampMagnitude(_rb.linearVelocity, _maxSpeed);
        }
    }

    private void LateUpdate()
    {
        _acid.transform.position = transform.position;
    }

    IEnumerator ReplicateCoroutine()
    {
        while (true)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                float proportion = (float)(_maxBacteriaCount - numBacteria) / _maxBacteriaCount;
                float probSpawn = proportion * (1 - Mathf.Pow(0.5f, 1 / _initialReplicatePeriod));
                bool spawnBacteria = Random.Range(0f, 1f) < probSpawn;
                if (spawnBacteria)
                {
                    GameObject newBacteria = PhotonNetwork.Instantiate(Path.Combine("Prefabs",
                        "LactoBacteria"), Vector3.zero, Quaternion.identity);
                    newBacteria.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(300 * Random.insideUnitCircle);
                    numBacteria++;
                }
            }
            yield return new WaitForSeconds(1);
        }
        
    }

    IEnumerator DeathTimer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            float timer = 0f;
            while (timer < _lifeSpan)
            {
                yield return null;
                timer += Time.deltaTime;
            }
            numBacteria--;
            PhotonNetwork.Destroy(transform.parent.gameObject);
        }
    }

}
