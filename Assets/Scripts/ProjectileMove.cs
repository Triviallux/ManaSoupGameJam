using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    // speed of projectile
    public float speed;
    public float livetime = 3;

    // rate of fire
    public float rateOfFire;

    private void Start()
    {
        Destroy(gameObject, livetime);
    }

    void Update()
    {
        if (speed >= 0)
            Move();
        else
            Debug.Log("Speed to low");
    }
    
    // moves the projectile
    void Move()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 0);
    }
}
