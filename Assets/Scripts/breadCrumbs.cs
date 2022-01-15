using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadCrumbs : MonoBehaviour
{

    bool Buttonreset;
    public GameObject Breadcrumbs;
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1) && Buttonreset)
        {
            DropBreadCrumbs();
            Buttonreset = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Buttonreset = true;
        }




    }


    public void DropBreadCrumbs() {

        Instantiate(Breadcrumbs, this.transform.position, this.transform.rotation);
    
    }
}
