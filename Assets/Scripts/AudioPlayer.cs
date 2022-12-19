using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audio;
    private AudioSource audioSource;
    private bool firstPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audio != null)
        {
            audioSource.clip = audio;
            
            if(other.tag == "Player" && firstPlay)
            {
                audioSource.Stop();
                audioSource.time = 0;
                audioSource.Play();
                firstPlay = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && transform.name != "background")
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
