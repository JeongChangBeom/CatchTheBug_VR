using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public ParticleSystem Spray;

    public AudioClip audioSpray;
    

    void Update()
    {
        SprayShot();
    }

    void PlaySpraySound()
    {
        if (this.gameObject.GetComponent<AudioSource>().isPlaying) return;
        else this.gameObject.GetComponent<AudioSource>().PlayOneShot(audioSpray);

        Debug.Log("play spray sound");
    }
    void SprayShot()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger))
        {
            Spray.Play();
            PlaySpraySound();
        }
    }
}
