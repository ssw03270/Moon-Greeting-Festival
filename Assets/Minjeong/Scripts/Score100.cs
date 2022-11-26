using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score100 : MonoBehaviour
{
    public bool is100;
    private void OnCollisionEnter(Collision collision)
    {
        if(Score.bowScoreType == 0)
            Score.bowScoreType = 100;
        is100 = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {

        is100 = false;
    }
    
    private void OnCollisionExit(Collision collision)
    {

        is100 = false;
    }
   
}
