using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed;
    private Vector2 moveDir;
    public float rotationSpeed;

    #region References
    public Rigidbody2D rb;
    private EnergyControl _energyControl;
    #endregion

    public bool controlWithMouse;
    // Start is called before the first frame update
    private void Start()
    {
        _energyControl = GetComponent<EnergyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float initRotation = transform.rotation.eulerAngles.z;
        ProcessInputs();
        float finalRotation = transform.rotation.eulerAngles.z;
        _energyControl.ModifyEnergy(-_energyControl.energyDrainRotation * Mathf.Abs(finalRotation - initRotation));
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
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (_energyControl.Energy > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
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

    
}
