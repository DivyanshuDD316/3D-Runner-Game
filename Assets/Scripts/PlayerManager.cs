using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed =500f;
    //[SerializeField] private float sensitivity = 100f;
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
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
        if(Input.GetAxis("Mouse X")>1f)
        {
            motor.CameraRot(new Vector3(0,90f,0));
        }
        else if(Input.GetAxis("Mouse X")<-1f)
        {
            motor.CameraRot(new Vector3(0,-90f,0));
        }
    }

}
