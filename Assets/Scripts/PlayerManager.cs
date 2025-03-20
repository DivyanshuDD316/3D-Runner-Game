using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed =500f;
    //[SerializeField] private float sensitivity = 100f;
    private PlayerMotor motor;

    private Vector2 mouseStartingPosition;
    private Vector2 mouseEndingPosition;
    private float swipeThreshold=5f;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void FixedUpdate()
    {
        CallMovement();
        CallRotation();
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
        float swipeDistanceX = mouseEndingPosition.x - mouseStartingPosition.x;

        if(Mathf.Abs(swipeDistanceX)>swipeThreshold)
        {
            if(swipeDistanceX>0f)
            motor.CameraRot(90f);
            else
            motor.CameraRot(-90f);
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is collided with Ground");
            motor.IsJumping();
        }
    }

}
