using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHunt : MonoBehaviour
{
    public GameObject Licht;
    public GameObject Player;
    LayerMask FloorMask;
    LayerMask PlayerMask;

    float CheckRadius = 2;
    public AudioSource audio;
    public AudioClip Gotcha;
    public GameObject HuntingWitch;
    bool foundHim;
    private void Start()
    {
        foundHim = false;
        FloorMask = LayerMask.GetMask("Floor");
        PlayerMask = LayerMask.GetMask("Player");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    [ExecuteInEditMode]
    public void CheckForPlayer() {
        if (foundHim)
            return;
       
        // Ich schwöre bei Gott ich habe alles Versucht aber diese hier z udeklarieren war der einzifge ausweg. 
        FloorMask = LayerMask.GetMask("Floor");
        PlayerMask = LayerMask.GetMask("Player");
        Player = GameObject.FindGameObjectWithTag("Player");


        RaycastHit hit;

        //Wir senden einen Raycast und an der stelle Chekcen wir mitr einer sphere nach dfem Player
       

        Debug.DrawRay(Licht.transform.position, Licht.transform.forward, Color.red, Mathf.Infinity);

        if (Physics.Raycast(Licht.transform.position, Licht.transform.forward, out hit, Mathf.Infinity, FloorMask))
        {
            

            bool Playerizda = Physics.CheckSphere(hit.point, CheckRadius, PlayerMask);
           
            if (Playerizda)
            {
                //Befindet sich der Player im radius beginnt die Hunt
                foundHim = true;
                WitchHunting();

            }
            
        }



    }

    public void WitchHunting() {

        Vector3 playerPos = Player.transform.position;
        Vector3 playerDirection = Player.transform.forward;
        Quaternion playerRotation = Player.transform.rotation;
        float spawnDistance = 30;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        spawnPos.y += 10;
        //Vector3 WitchPos = new Vector3(Player.transform.position.x + Random.Range(30, 50), Player.transform.position.y + 10, Player.transform.position.z + Random.Range(30,50));
        Debug.Log("DIE JAGD BEGINNT!");
        Instantiate(HuntingWitch, spawnPos, HuntingWitch.transform.rotation);
        audio.clip = Gotcha;
        audio.Play();


}






}
