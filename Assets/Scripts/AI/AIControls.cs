using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour
{
    
    public float movementSpeed;
    public float turningSpeed;
    public float turretTurningSpeed;
    public float shootingCooldown;
    
    public Transform turret;
    public Transform muzzle;
    public GameObject projectile;
    
    private Rigidbody rb;
    private float t;
    private GameObject targetObject;
    private Vector3 target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {

        Vector3 currentRotation = rb.transform.eulerAngles;
        rb.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);    // tank is allowed to rotate only around y-axis  --> prevents from rolling over
        
        // find player
        if (targetObject != null)
        {
            target = targetObject.transform.position; 
        }
        else
        {
            targetObject = GameObject.FindGameObjectWithTag("Player");    
        }
        
        // move towards player: in which angle player is aligned towards (this) enemy
        float angle = Vector3.SignedAngle(transform.forward, target - transform.position, Vector3.up);

        if (angle < 0)
        {
            Turning((-1f));
        }
        else if (angle > 0)
        {
            Turning(1f);
        }

        // player is in front of 180 deg view --> if so, move towards player  
        if (Math.Abs(angle) < 90)
        {
            Move(1f);
        }


    }

    private void Move(float input)
    {
        Vector3 movement = transform.forward * input * movementSpeed;
        rb.velocity = movement;
    }

    private void Turning(float input)
    {
        Vector3 turning = Vector3.up * input * turningSpeed;    
        rb.angularVelocity = turning;   
    }
    
}
