using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float KillTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, KillTime);
    }

}
