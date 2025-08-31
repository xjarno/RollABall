using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private Rigidbody rb;
    private float hitForce;
    private float holdDownStartTime;
    private const float maxForce = 10f;
    [SerializeField] Transform cam;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            //starttime of when mousebutton is pressed
            holdDownStartTime = Time.time;
            Debug.Log("Mouse");
        }

        if (Input.GetMouseButtonUp(0)) 
        { 
            //adds force to player in camera direction.
            float holdDownTime = Time.time - holdDownStartTime;
            rb.AddForce(cam.forward.x * CalculateForce(holdDownTime),CalculateForce(holdDownTime), cam.forward.z * CalculateForce(holdDownTime), ForceMode.Impulse);
            Debug.Log(CalculateForce(holdDownTime));
        }
    }

    


    private float CalculateForce(float holdTime) 
    {
        // calculates how much force based on how long mousebutton is pressed.
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        hitForce = holdTimeNormalized * maxForce;
        return hitForce;
    }

}
