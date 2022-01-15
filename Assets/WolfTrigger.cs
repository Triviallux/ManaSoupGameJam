using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTrigger : MonoBehaviour
{
    public bool Inverse;
    public bool Sound;
    public bool wolf;
    public bool once;
    int c;
    public AudioSource audio;
    public GameObject Wolf;
    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player") && c == 0)
        {

            if (audio != null)
            {
                if (Sound && !audio.isPlaying && c == 0)
                {
                    audio.Play();
                    if (once)
                    {
                        c++;
                    }
                }
            }

            if (!Inverse)
            {
                if (Wolf != null)
                {
                    Wolf.SetActive(true);
                }
               
            }
            else
            {
                if (Wolf != null)
                {
                    Wolf.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!Inverse)
            {
                if (Wolf != null)
                {
                    Wolf.SetActive(false);
                }
            }
            else
            {
                if (Wolf != null)
                {
                    if (once)
                        return;
                    Wolf.SetActive(true);
                }
            }
        }
    }



}
