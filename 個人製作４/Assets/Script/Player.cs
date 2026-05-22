
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    Vector2 moveInput;



    public float Speed = 5f;
    public float jumpPower = 7f;



    Rigidbody rb;
    bool isGrounded;





































































































    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * Speed * Time.deltaTime, Space.World);
    }



    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }



    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            Debug.Log("Jump!");



            rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpPower,
            rb.linearVelocity.z
            );
        }
    }



    // �n�ʔ���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }



    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
