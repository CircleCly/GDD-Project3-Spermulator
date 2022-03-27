using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorSpermAI: MonoBehaviour
{

    public GameObject firstWaypoint;

    private GameObject _target;

    public float moveSpeed;

    public float rotationSpeed;

    private float _reachThres = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _target = firstWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector2(1, 0) * moveSpeed * Time.deltaTime;
        if (Vector2.Distance(transform.position, _target.transform.position) < _reachThres)
        {
            _target = _target.GetComponent<Waypoint>().getNextWaypoint();
        }

    }

}
