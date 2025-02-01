using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed =500f;
    private PlayerMotor motor;
    float yRot;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 LR = horizontal * Vector3.right * speed * Time.deltaTime;
        motor.Velocity(LR);

        yRot += Input.GetAxis("Mouse X");
        Vector3 Rotation = new Vector3(0,yRot,0);
        motor.CameraRot(Rotation);
    }
}
