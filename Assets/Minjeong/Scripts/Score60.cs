using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score60 : MonoBehaviour
{
    public bool is60;
    private void OnCollisionEnter(Collision collision)
    {
        if(Score.bowScoreType == 0)
            Score.bowScoreType = 60;
        is60 = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {

        is60 = false;
    }
    
    private void OnCollisionExit(Collision collision)
    {

        is60 = false;
    }
   
}
