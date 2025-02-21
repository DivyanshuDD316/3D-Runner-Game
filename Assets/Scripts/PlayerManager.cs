using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed =500f;
    //[SerializeField] private float sensitivity = 100f;
    private PlayerMotor motor;

    private Vector2 mouseStartingPosition;
    private Vector2 mouseEndingPosition;
    bool isGrounded=false;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        CallMovement();
        CallRotation();
        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                motor.Jump();
            }
        }
    }
    
    void CallMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 LR = horizontal * transform.right * speed * Time.deltaTime;
        motor.Velocity(LR);
    }
    void CallRotation()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseStartingPosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            mouseEndingPosition = Input.mousePosition;
            RotationAngle();
        }
    }
    void RotationAngle()
    {
        if(mouseEndingPosition.x-mouseStartingPosition.x>1f) motor.CameraRot(90f);
        else if(mouseEndingPosition.x-mouseStartingPosition.x<-1f) motor.CameraRot(-90f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
        }
    }

}
