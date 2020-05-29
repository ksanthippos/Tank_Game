using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float time;
    public float radius;
    public float damage;

    public string shooterTag;

    private Rigidbody rb;
    private float t;
    
    // Start is called before the first frame update
    void Start()
    {
        t = time;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0)
        {
            
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Muzzle") && !other.CompareTag(shooterTag))
        {
            Explode();    
        }
        
    }
}
