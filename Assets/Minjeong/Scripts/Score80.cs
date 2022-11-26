using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score80 : MonoBehaviour
{
    public bool is80;
    private void OnCollisionEnter(Collision collision)
    {
        if(Score.bowScoreType == 0)
            Score.bowScoreType = 80;
        print(Score.bowScoreType);
        is80 = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {

        is80 = false;
    }
    
    private void OnCollisionExit(Collision collision)
    {

        is80 = false;
    }
   
}
