using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingWitch : MonoBehaviour
{
    public GameObject Player, deathWitch;
    public Vector3 lastSeenAt;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        lastSeenAt = Player.transform.position;
        this.transform.LookAt(lastSeenAt);
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        //death
        Vector3 playerPos = Player.transform.position;
        Vector3 playerDirection = Player.transform.forward;
        Quaternion playerRotation = Player.transform.rotation;
        float spawnDistance = 1f;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        spawnPos.y += 0.5f;
        GameObject Witch = Instantiate(deathWitch, spawnPos, deathWitch.transform.rotation);
        Witch.transform.LookAt(Player.transform);
        Debug.Log("Bitte bitite ");
    }
}
