using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    [SerializeField] private float speed=1000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        anim=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rb.AddForce(0,0,speed * Time.fixedDeltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity=Vector3.forward*horizontal * 555f * Time.fixedDeltaTime;
    }
}
