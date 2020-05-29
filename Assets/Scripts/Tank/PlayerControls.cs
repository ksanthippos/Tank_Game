﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    // public variables can be accessed in Unity editor
    public float movementSpeed;
    public float turningSpeed;
    public float turretTurningSpeed;
    public float shootingCooldown;
    
    public Transform turret;
    public Transform muzzle;
    public GameObject projectile;
    
    private Rigidbody rb;
    private Camera mainCamera;
    private float maxRayDistance = 100f;
    private int floorMask;
    private float t;
    
    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        floorMask = LayerMask.GetMask("Floor");
    }

    private void Update()
    {
        if (t <= 0)    // allowed to shoot
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject proj = Instantiate(projectile, muzzle.position, muzzle.rotation);
                proj.GetComponent<Projectile>().shooterTag = tag;
                t = shootingCooldown;
            }    
        }
        else
        {
            t -= Time.deltaTime;
        }
    }


    // Update is called once per frame
    void FixedUpdate() // 
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        // turning left and right
        if (inputHorizontal != 0)
        {
            Vector3 turning = Vector3.up * inputHorizontal * turningSpeed;    
            rb.angularVelocity = turning;   
        }

        // moving forw/backw
        if (inputVertical != 0)
        {
            Vector3 movement = transform.forward * inputVertical * movementSpeed;
            rb.velocity = movement;
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);    // ray pointing towards mouse cursor
        RaycastHit hit;    // point where ray hits

        if (Physics.Raycast(ray, out hit, maxRayDistance, floorMask))
        {
            Vector3 targetDirection = hit.point - turret.position;
            targetDirection.y = 0f;
            Vector3 turningDirection = Vector3.RotateTowards(turret.forward, targetDirection, turretTurningSpeed * Time.deltaTime, 0f);
            turret.rotation = Quaternion.LookRotation(turningDirection);
        }


    }

}
