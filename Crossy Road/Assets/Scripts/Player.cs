using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce = 112f;
    public float groundCheckDistance = 0.3f;
    private bool isGrounded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, groundCheckDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AdjustPositionAndRotation(new Vector3(0, 0, 0));
                rb.AddForce(new Vector3(0, jumpForce, jumpForce));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AdjustPositionAndRotation(new Vector3(0, 180, 0));
                rb.AddForce(new Vector3(0, jumpForce, -jumpForce));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AdjustPositionAndRotation(new Vector3(0, -90, 0));
                rb.AddForce(new Vector3(-jumpForce, jumpForce, 0));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AdjustPositionAndRotation(new Vector3(0, 90, 0));
                rb.AddForce(new Vector3(jumpForce, jumpForce, 0));
            }
        }
    }

    void AdjustPositionAndRotation(Vector3 newRotation)
    {
        rb.velocity = Vector3.zero;
        transform.eulerAngles = newRotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StepTrigger"))
        {
            LevelManager.levelManager.SetSteps();
            Destroy(other.gameObject);
        }
    }
}
