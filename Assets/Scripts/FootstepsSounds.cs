using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSounds : MonoBehaviour
{
    public PlayerMovement pp;
    public CharacterController cc;

    public List<AudioClip> audiolist;
    public AudioSource audio;
    private void Start()
    {
        pp = GetComponent<PlayerMovement>();
        cc = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (cc.velocity.magnitude >= 0.1f && !audio.isPlaying)
        {
            audio.clip = audiolist[Random.Range(0, audiolist.Count)];
            audio.volume = Random.Range(0.2f, 0.45f);
            audio.Play();
        }
    }
}
