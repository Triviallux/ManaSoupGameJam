using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGoal : MonoBehaviour
{
    int Lockcounter;
    public List<GameObject> Locks;
    public GameManager gm;

    public AudioSource audio;
    public int Zielnummer = 3;
    public int akutenummer;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (akutenummer >= Zielnummer)
        {
            gm.Success();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalItem"))
        {

            Locks[akutenummer].GetComponent<Animator>().SetBool("open", true);
            Locks[akutenummer].GetComponent<AudioSource>().Play();
            Lockcounter++;
            akutenummer++;
            other.gameObject.SetActive(false);
            audio.Play();
        }
    }
}
