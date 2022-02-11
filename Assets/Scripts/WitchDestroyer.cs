using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchDestroyer : MonoBehaviour
{


    WitchManager WitchM;
    public float KillTimeSec;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

        WitchM = FindObjectOfType<WitchManager>();

    }




    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= KillTimeSec)
        {

            WitchM.DestroCurrentWitch();
        
        }



    }
}
