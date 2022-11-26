using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score40 : MonoBehaviour
{
    public bool is40;
    private void OnCollisionEnter(Collision collision)
    {
        if(Score.bowScoreType == 0)
            Score.bowScoreType = 40;
        is40 = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {

        is40 = false;
    }
    
    private void OnCollisionExit(Collision collision)
    {

        is40 = false;
    }
   
}
