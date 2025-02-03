using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed =500f;
    [SerializeField] private float sensitivity = 100f;
    private PlayerMotor motor;
    float yRot;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 LR = horizontal * transform.right * speed * Time.deltaTime;
        motor.Velocity(LR);

        yRot += Input.GetAxis("Mouse X");
        Vector3 Rotation = new Vector3(0,yRot*sensitivity,0);
        motor.CameraRot(Rotation);
    }
}
