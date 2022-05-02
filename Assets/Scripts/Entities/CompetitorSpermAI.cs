using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CompetitorSpermAI: MonoBehaviour
{

    public GameObject firstWaypoint;

    private GameObject _target;

    private PhotonView _pv;

    public Color c;


    #region General movement

    public float moveSpeed;

    public float rotationSpeed;

    private float _reachThres = 0.1f;



    #endregion

    #region Obstacle evasion
    private CompetitorSensor _sensor;

    private PHControl _pHControl;

    public float evasionImportance;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _pHControl = GetComponent<PHControl>();
        _sensor = GetComponentInChildren<CompetitorSensor>();
        _target = firstWaypoint;
        _pv = GetComponent<PhotonView>();
        if (_pv.IsMine)
        {
            _pv.RPC("RPC_SendColor", RpcTarget.AllBuffered, c.r, c.g, c.b);
        }
    }

    [PunRPC]
    public void RPC_SendColor(float r, float g, float b)
    {
        Color c = new Color(r, g, b);
        Debug.Log(c);
        GetComponent<SpriteRenderer>().color = c;
        GetComponentInChildren<LineRenderer>().material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PhotonNetwork.IsMasterClient);
        if (PhotonNetwork.IsMasterClient)
        {
            ProcessMovement();
        }

    }

    private void ProcessMovement()
    {
        Debug.Log(_target.transform.position);
        Vector2 moveDir = (_target.transform.position - transform.position).normalized;
        float waypointAngle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        Vector2 evadeDir = GetEvadeDirection();
        float angle;
        if (evadeDir.Equals(Vector2.zero))
        {
            angle = waypointAngle;
        }
        else
        {
            float evasionAngle = Mathf.Atan2(evadeDir.y, evadeDir.x) * Mathf.Rad2Deg;
            angle = waypointAngle * (1 - evasionImportance) + evasionAngle * evasionImportance;
        }

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.position = transform.position +
            Quaternion.Euler(0, 0, angle) * new Vector2(1, 0) * Random.Range(0.85f, 1.15f)
            * moveSpeed * Time.deltaTime;
        if (Vector2.Distance(transform.position, _target.transform.position) < _reachThres)
        {
            _target = _target.GetComponent<Waypoint>().getNextWaypoint();
        }
    }

    Vector2 GetEvadeDirection()
    {
        float pHPercent = (_pHControl.PH - _pHControl.minPH) / (_pHControl.maxPH - _pHControl.minPH);
        if (pHPercent < 0.5 && _sensor.acidDetected)
        {
            return Quaternion.Euler(0, 0, 180) * (_sensor.acidPosition - transform.position);
        } else if (pHPercent >= 0.5 && _sensor.baseDetected)
        {
            return Quaternion.Euler(0, 0, 180) * (_sensor.basePosition - transform.position);
        }
        return new Vector3(0, 0, 0);
    }

    
}
