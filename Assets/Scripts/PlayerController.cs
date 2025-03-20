using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController control;
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float sensitivity = 50f;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAndMovement();
        PlayerRotation();
    }
    void JumpAndMovement()
    {
        float xAxis = Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 move = forwardSpeed * transform.forward + xAxis * transform.right;
        control.Move(move * Time.deltaTime);

        isGrounded = control.isGrounded || Physics.Raycast(transform.position, Vector3.down, 0.2f );
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        if(isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {Debug.Log("Button is pressed");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
    }
    void PlayerRotation()
    {
        float targetRotation = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(targetRotation * Vector3.up);
    }
}
