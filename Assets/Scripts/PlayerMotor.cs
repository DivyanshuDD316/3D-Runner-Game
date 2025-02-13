using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity=Vector3.zero;
    private Quaternion rotation = Quaternion.identity;
    [SerializeField] float speed = 1000f;
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
        rotation *= Quaternion.Euler(0,angle,0);
    }
    
    void FixedUpdate()
    {
        PlayerMovement();
        PerformRotation();
    }
    private void PlayerMovement()
    {
        rb.AddForce(transform.forward*speed*Time.fixedDeltaTime);
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
