using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float currentSpeed =0, acceleration = 60;
    [SerializeField] private float turnSpeed = 100, minAcceleration, maxAcceleration, minSpeed, maxSpeed;
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private TakeDamage takeDamage;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isGrounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);
        if (isGrounded && !takeDamage.isHurt)
        {
            if (Input.GetKey(leftInput) && transform.eulerAngles.y < 271) 
            {
                transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0), Space.Self);
            }
            
            if (Input.GetKey(rightInput) && transform.eulerAngles.y > 91)
            {
                transform.Rotate(new Vector3(0, - turnSpeed * Time.deltaTime, 0), Space.Self);
            } 
        }
    }

    private void FixedUpdate()
    {
        if (takeDamage.isHurt)
            return;
        float angle = Mathf.Abs(180 - transform.eulerAngles.y); //lenķi rēķina
        acceleration = Remap(0, 90, maxAcceleration, minAcceleration, angle); //ātruma un lenka salidzinasana
        currentSpeed += acceleration * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        Vector3 velocity = transform.forward * currentSpeed * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        animator.SetFloat("playerSpeed", currentSpeed);
        
    }

    private float Remap(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }
}
