using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public TextMeshProUGUI strokesText;
    private Rigidbody rb;
    private int Strokes;
    private float hitForce;
    private float holdDownStartTime;
    private const float maxForce = 20f;
    [SerializeField] Transform cam;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.IsSleeping()) 
        {
        Move();
        }
        SetStrokesText();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            //starttime of when mousebutton is pressed
            holdDownStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0)) 
        { 
            //adds force to player in camera direction.
            float holdDownTime = Time.time - holdDownStartTime;
            rb.AddForce(cam.forward.x * CalculateForce(holdDownTime), 0, cam.forward.z * CalculateForce(holdDownTime), ForceMode.Impulse);
            Strokes++;
        }
    }

    void SetStrokesText()
    {
        strokesText.text = "Strokes: " + Strokes.ToString();
    }

    private float CalculateForce(float holdTime) 
    {
        // calculates how much force based on how long mousebutton is pressed.
        float maxForceHoldDownTime = 1.5f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        hitForce = holdTimeNormalized * maxForce;
        return hitForce;
    }
}
