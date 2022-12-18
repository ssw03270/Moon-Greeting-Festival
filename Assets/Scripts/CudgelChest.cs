using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CudgelChest : MonoBehaviour
{
    public AudioClip audio;
    private AudioSource audioSource;

    public int score;

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

            if (other.tag == "Cudgel")
            {
                audioSource.Stop();
                audioSource.time = 0;
                audioSource.Play();
                score += 1;
            }
        }
    }
}
