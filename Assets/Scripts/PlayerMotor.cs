using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity=Vector3.zero;
    private Quaternion rotation = Quaternion.identity;
    private bool isGrounded = false;
    //private bool isSlideMode = false;
    [SerializeField] float moveSpeed = 100f;
    [SerializeField] float jumpForce = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Velocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void CameraRot(float angle)
    {
        rotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);
    }
    public void IsJumping()
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {
        PlayerMovement();
        PerformRotation();
        if(isGrounded)
        {
            Debug.Log("Player is Grounded");
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce(jumpForce * Vector3.up * Time.deltaTime, ForceMode.Impulse);
                isGrounded = false;
                Debug.Log("Jump Button Pressed");
            }
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                
            }
        }
    }
    private void PlayerMovement()
    {
        rb.MovePosition(rb.position + transform.forward*moveSpeed*Time.fixedDeltaTime);
        if(velocity!=Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    private void PerformRotation()
    {
        if(rotation !=Quaternion.identity)
        {
            rb.MoveRotation(rotation);
        }
    }
}
