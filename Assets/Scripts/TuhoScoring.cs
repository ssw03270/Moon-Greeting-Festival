using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoScoring : MonoBehaviour
{
    public int score;
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
        if(other.tag == "Arrow")
        {
            score += 1;

            if(score >= 3)
            {
                print("clear");
            }
        }
    }
}
