using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 moveDir;
    public float rotationSpeed;
    private EnergyControl _energyControl;
    // Start is called before the first frame update
    private void Start()
    {
        _energyControl = GetComponent<EnergyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
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
        }

        
    }

    void Move()
    {
        //rb.AddForce(new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed));
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
