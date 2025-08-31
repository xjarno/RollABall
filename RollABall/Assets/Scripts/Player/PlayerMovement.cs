using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float hitForce;
    private float holdDownStartTime;
    private const float maxForce = 10f;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
            Debug.Log("Mouse");
        }

        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            rb.AddForce(0, CalculateForce(holdDownTime), 0, ForceMode.Impulse);
            Debug.Log(CalculateForce(holdDownTime));
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            holdDownStartTime = Time.time;
            Debug.Log("Mouse");
        }

        if (Input.GetMouseButtonUp(0)) 
        { 
            float holdDownTime = Time.time - holdDownStartTime;
            rb.AddForce(0,CalculateForce(holdDownTime),0,ForceMode.Impulse);
            Debug.Log(CalculateForce(holdDownTime));
        }
    }

    private float CalculateForce(float holdTime) 
    {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        hitForce = holdTimeNormalized * maxForce;
        return hitForce;
    }
}
