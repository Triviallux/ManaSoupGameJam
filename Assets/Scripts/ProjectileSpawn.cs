using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;

public class ProjectileSpawn: MonoBehaviour
{
    // a gameobject that spawns the projectile (hand, cannon, ...)
    public GameObject spawnpoint;

    // list of projectiles that we want to spawn
    public List<GameObject> projectiles = new List<GameObject>();


    // path that the witch follows as PathCreator
    public PathCreator witchPath;

    // Radius of detector sphere around this object
    public float radiusDetect;

    // the projectile GameObject we want to spawn
    private GameObject projectileToSpawn;

    // the player
    private GameObject player;

    // timeout
    public float timeout;

    // 
    private float cooldownTimer = 10;
    private bool timeoutActive = false;
    public ProjectileTargeting projectileTargeting;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        projectileToSpawn = projectiles[0];
    }

    void Update()
    {
        List<Collider> colliders = new List<Collider>();
        if (radiusDetect > 0)
        {
            colliders = new List<Collider>(Physics.OverlapSphere(transform.position, radiusDetect));
            if (witchPath != null)
                DetectPlayer(colliders);
            else
                Debug.Log("No Path for witch");

        }
        else
            Debug.Log("Detection radius to small");               
    }

    // Detect Player with sphere around witch
    void DetectPlayer(List<Collider> colliders) {
        if (colliders.Any())
        {
            Collider c = colliders.Find(c => c.tag == player.tag);
            if (c != null)
                SpawnProjectile();
        }
        else
            Debug.Log("No collisions detected");
    }

    // spawn projectile at spawnpoint
    void SpawnProjectile()
    {
        GameObject spawnedProjectile;

        if (spawnpoint != null)
            if (!timeoutActive)
            {
                spawnedProjectile = Instantiate(projectileToSpawn, spawnpoint.transform.position, Quaternion.identity);
                spawnedProjectile.transform.localRotation = projectileTargeting.GetRotation();
                cooldownTimer = timeout;
                timeoutActive = true;
            }
            else if (cooldownTimer <= 0)
                timeoutActive = false;
            else
                cooldownTimer -= Time.deltaTime;
        else
            Debug.Log("No spawnpoint for projectile set");
    }

    // draw sphere to debug detection radius reach
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusDetect);
    }
}
