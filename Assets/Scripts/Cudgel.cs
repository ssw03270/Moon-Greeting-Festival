using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cudgel : MonoBehaviour
{
    public Grabbable grabbable;
    public CudgelChest cudgelChest;
    public AudioClip audioStart;
    public AudioClip audioEnd;
    private AudioSource audioSource;

    private bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (grabbable != null)
        {
            if (grabbable.BeingHeld && isFirst)
            {
                audioSource.clip = audioStart;
                audioSource.Stop();
                audioSource.time = 0;
                audioSource.Play();
                isFirst = false;
            }
        }

        if(cudgelChest.score == 5)
        {
            audioSource.clip = audioEnd;
            audioSource.Stop();
            audioSource.time = 0;
            audioSource.Play();
            cudgelChest.score = -999;
        }
    }
}
