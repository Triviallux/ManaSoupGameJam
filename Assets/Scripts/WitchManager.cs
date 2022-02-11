using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchManager : MonoBehaviour
{

    public bool PlayerinSafeZone;
    public bool WitchSpawned;


    public Transform WitchPoint;
    public GameObject Witch, Player;
    private GameObject CurrentWitch;

    public float ChanceInProzent = 20;
    public float TimeBetweenWitches = 20;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!PlayerinSafeZone && !WitchSpawned && timer > TimeBetweenWitches)
        {
            timer = 0;
            int R_NUM = Random.Range(0, 100);
           
            if (R_NUM <= ChanceInProzent)
            {
               
                CurrentWitch = Instantiate(Witch, GetWitchPositioninFrontofPlayer(), Witch.transform.rotation * Player.transform.rotation);
                WitchSpawned = true;
            }
        }

    }

    public void DestroCurrentWitch() {

        Destroy(CurrentWitch);
        CurrentWitch = null;
        WitchSpawned = false;
    
    }

    public Vector3 GetWitchPositioninFrontofPlayer()
    {
        var position = WitchPoint.position;
        return position;

    }

    public Vector3 GetRandomPositioninFrontofPlayer()
    {

        var distance = 10.0f;
        var tolerance = 1f;
        var offset = Player.transform.forward * distance;
        var position = offset + new Vector3(Player.transform.position.x - 5, Player.transform.position.y + Random.Range(20f, 30f), Player.transform.position.z + Random.Range(-tolerance, tolerance));
        return position;

    }






}
