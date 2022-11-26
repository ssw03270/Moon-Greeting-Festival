using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject Score10;
    public GameObject Score8;
    public GameObject Score6;
    public GameObject Score4;
    public GameObject Score2;
    public VRCanvas ScoreUI;

    public Bow bow;

    private Text _ScoreText;
    private Score20 _Score20;
    private Score40 _score40;
    private Score60 _score60;
    private Score80 _score80;
    private Score100 _score100;

    public static int bowScoreType = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _Score20 = Score2.GetComponent<Score20>();
        _score40 = Score4.GetComponent<Score40>();
        _score60 = Score6.GetComponent<Score60>();
        _score80 = Score8.GetComponent<Score80>();
        _score100 = Score10.GetComponent<Score100>();

        _ScoreText = ScoreUI.transform.Find("ScoreText").GetComponent<Text>();

    }
    

    // Update is called once per frame
    void Update()
    {
        if (bow.StringDistance > 0)
        {
            bowScoreType = 0;
        }
        if (bowScoreType == 20)
        {
            _ScoreText.text = "20";
            
        }
        else if (bowScoreType == 40)
        {
            _ScoreText.text = "40";
        }
        else if (bowScoreType == 60)
        {
            _ScoreText.text = "60";
        }
        else if (bowScoreType == 80)
        {
            _ScoreText.text = "80";
        }
        else if (bowScoreType == 100)
        {
            _ScoreText.text = "100";
        }
        else
        {
            _ScoreText.text = "";
        }

    }
    
    
    IEnumerator UI20Show()
    {
        yield return new WaitForSeconds(1f);
        _ScoreText.text = "20";
    }

}
