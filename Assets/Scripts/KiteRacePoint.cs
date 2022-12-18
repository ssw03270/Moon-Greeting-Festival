using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteRacePoint : MonoBehaviour
{
    public Kite kite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!kite.isRaceFinished && other.tag == "Player")
        {
            kite.audioSource.Stop();
            print("goal");
        }
    }
}
