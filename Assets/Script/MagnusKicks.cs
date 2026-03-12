using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusKicks : MonoBehaviour
{

    [SerializeField] float kickForce;
    [SerializeField] float spinAmount;
    [SerializeField] float magnusStregth = 0.5f;

    Rigidbody rb;
    bool isShot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isShot)
        { 
            rb.AddForce(Vector3.back * kickForce , ForceMode.Impulse);
            rb.AddTorque(Vector3.up * spinAmount);

            isShot = true;
        
        }
        
    }


    private void FixedUpdate()
    {
        if (!isShot) return;
        {
            Vector3 velocity = rb.linearVelocity;
            Vector3 spin = rb.angularVelocity;

            Vector3 MagnusForce = magnusStregth * Vector3.Cross(spin, velocity);
                rb.AddForce(MagnusForce);
        }
            
    }
}
