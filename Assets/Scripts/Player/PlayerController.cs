using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed;
    private Vector2 moveDir;
    public float rotationSpeed;
    public float distTravelled;
    public float time;
    

    #region References
    public Rigidbody2D rb;
    private EnergyControl _energyControl;
    private PHControl _pHControl;
    private AudioSource _hitAudio;
    #endregion

    public bool controlWithMouse;
    // Start is called before the first frame update
    private void Start()
    {
        _energyControl = GetComponent<EnergyControl>();
        _pHControl = GetComponent<PHControl>();
        _hitAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float initRotation = transform.rotation.eulerAngles.z;
        Vector2 initPosition = transform.position;
        ProcessInputs();
        float finalRotation = transform.rotation.eulerAngles.z;
        Vector2 finalPosition = transform.position;
        _energyControl.ModifyEnergy(-_energyControl.energyDrainRotation * Mathf.Abs(finalRotation - initRotation));
        distTravelled += Vector2.Distance(initPosition, finalPosition);
        time += Time.deltaTime;
    }

    void ProcessInputs()
    {
        if (controlWithMouse)
        {
            MouseControl();
        } else
        {
            KeyboardControl();
        }
        
    }

    void MouseControl()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDir = mousePoint - transform.position;
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (_energyControl.Energy > 0)
        {
            float speedPercent = Mathf.Clamp01(moveDir.magnitude / 3f);
            transform.position = Vector2.MoveTowards(transform.position, mousePoint, speedPercent * moveSpeed * Time.deltaTime);
            _energyControl.ModifyEnergy(-speedPercent * _energyControl.energyDrain);
        }
    }

    void KeyboardControl()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY);
        if (_energyControl.Energy <= 0)
        {
            moveDir = Vector2.zero;
        }
        if (moveDir != Vector2.zero)
        {
            //transform.Rotate(new Vector3(0, 0, -0.5f * moveX));
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            transform.position = transform.position + new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            _energyControl.ModifyEnergy(-_energyControl.crashEnergyDecrease);
            _pHControl.PH -= _pHControl.crashPHDecrease;
            _hitAudio.Play();
        } else if (collision.gameObject.CompareTag("Bottom"))
        {
            GameManager.Instance.AltEnding();
        }
    }

}
