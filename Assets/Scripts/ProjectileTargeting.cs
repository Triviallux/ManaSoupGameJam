using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTargeting : MonoBehaviour
{

    // direction of player viewed from projectile
    private Vector3 direction;
    // rotation of projectile
    private Quaternion rotation;

    //the player
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        RotateProjectileToPlayer();
    }

    void RotateProjectileToPlayer()
    {
        if (player != null)
        {
            direction = player.transform.position - transform.position;
            rotation = Quaternion.LookRotation(direction);
            transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, 1);
            Debug.DrawRay(transform.position,direction);
        }
        else
            Debug.Log("No GameObject with tag \"Player\"");
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}
