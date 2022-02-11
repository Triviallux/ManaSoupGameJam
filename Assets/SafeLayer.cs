using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoalItem"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 50, other.gameObject.transform.position.z);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;       
        }
    }
}
