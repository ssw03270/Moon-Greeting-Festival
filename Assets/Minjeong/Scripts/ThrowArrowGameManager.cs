using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BNG;
using UnityEngine;
using UnityEngine.UI;

public class ThrowArrowGameManager : MonoBehaviour
{ 
    public int count = 0; // count는 총 5회
    public Trigger TriggerBox; // mission trigger
    public TargetTrigger TargetTrigger; // Cylinder
    public GameObject[] archerarrow; // 상대 arrow 배열
    public GameObject Archer;
    public Bow bow;
    public Canvas ScoreUI;
    public Score score;
    
    //Stamp
    public Canvas ArrowStampUI;
    public Canvas ArrowMissionUI;
    public GameObject Backpack;
    public GameObject stamp;
    private bool isstampevent;
    private bool isRevert;
    
    private bool gameover;
    private float fTickTime;
    private float fTickTime2;
    private float fTickTime3;
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;
    private bool isfirstsound = true;
    private bool isOnesound = true;



    private bool firstend = false;
    private Animator _archeranim;
    
    

    public Text[] playerScoreText;
    public Text[] AIScoreText;

    private int sum;
    public string[] tempstring;

    // Start is called before the first frame update
    void Start()
    {

        // archer arrow visible
        archerarrow[0].SetActive(false); // 60점
        archerarrow[1].SetActive(false); // 0점
        archerarrow[2].SetActive(false); // 40점
        archerarrow[3].SetActive(false); // 20점
        archerarrow[4].SetActive(false); // 20점
        
        //archer animation
        _archeranim = Archer.GetComponent<Animator>();
        
        // UI
        ScoreUI.gameObject.SetActive(false);
        playerScoreText[0].gameObject.SetActive(false);
        playerScoreText[1].gameObject.SetActive(false);
        playerScoreText[2].gameObject.SetActive(false);
        playerScoreText[3].gameObject.SetActive(false);
        playerScoreText[4].gameObject.SetActive(false);
        playerScoreText[5].gameObject.SetActive(false);

        AIScoreText[0].gameObject.SetActive(false);
        AIScoreText[1].gameObject.SetActive(false);
        AIScoreText[2].gameObject.SetActive(false);
        AIScoreText[3].gameObject.SetActive(false);
        AIScoreText[4].gameObject.SetActive(false);
        AIScoreText[5].gameObject.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score._ScoreText +  "GameManger Scoretext");
        if (!gameover)
        {
            if (TriggerBox.isTrigger && count == 0) //first trigger, 게임 시작
            {
                Debug.Log("게임 시작");
                // (+게임 설명 UI 활성화)
                ArrowMissionUI.gameObject.SetActive(true);
                if (isfirstsound)
                {
                    UIAudioSource.clip = UIClip[0];
                    UIAudioSource.Play();
                    isfirstsound = false;
                }
                fTickTime += Time.deltaTime;
                
                if (fTickTime >= 3.0f )
                {
                    Debug.Log("미션 시작");
                    ArrowMissionUI.gameObject.SetActive(false);
                    ScoreUI.gameObject.SetActive(true);
                    // 2초 뒤에 실행
                    _archeranim.SetTrigger("DoDraw");
                    fTickTime = 0;
                    
                    count += 1;
                }
            }

            if (count == 1) // 1회차 AI turn
            {
                fTickTime += Time.deltaTime;

                if (fTickTime >= 1.0f)
                {
                    archerarrow[0].SetActive(true);
                    if (!TargetTrigger.isTrigger1)
                    {
                        archerarrow[0].transform.position += new Vector3(0, 0, 0.1f);
                    }
                    else if (TargetTrigger.isTrigger1)
                    {
                        AIScoreText[0].gameObject.SetActive(true);
                    }
                }
                if (bow.count == 1) // 2회차 player turn
                {

                    count += 1;
                    fTickTime = 0;
                }
            }

            if (count == 2) // 2회차
            {
                AIScoreText[0].gameObject.SetActive(true);
                playerScoreText[0].gameObject.SetActive(true);
                playerScoreText[0].text = score._ScoreText;
                if (playerScoreText[0].text != "0")
                {
                    tempstring[0] = score._ScoreText;
                }
                playerScoreText[0].text = tempstring[0];
                if (firstend == false) // count 처음에만 실행
                {
                    ScoreUI.gameObject.SetActive(true);
                    _archeranim.SetTrigger("DoDraw");
                    firstend = true;

                }
                
                fTickTime += Time.deltaTime;

                if (fTickTime >= 1.0f)
                {
                    archerarrow[1].SetActive(true);
                    if (!TargetTrigger.isTrigger2)
                    {
                        archerarrow[1].transform.position += new Vector3(0, 0, 0.1f);
                    }
                    else if (TargetTrigger.isTrigger2)
                    {
                        AIScoreText[1].gameObject.SetActive(true);
                    }
                }
                if (bow.count == 2) // 2회차 player turn
                {

                    count += 1; // 다음 회차로 넘김 
                    fTickTime = 0; // tick 시간 초기화
                    firstend = false; // 처음 실행 trigger 초기화
                }
            }
            
            if (count == 3) // 3회차
            {
                AIScoreText[1].gameObject.SetActive(true);
                playerScoreText[0].text = tempstring[0];
                playerScoreText[1].gameObject.SetActive(true);
                playerScoreText[1].text = score._ScoreText;

                if (playerScoreText[1].text != "0")
                {
                    tempstring[1] = score._ScoreText;
                }
                playerScoreText[1].text = tempstring[1];
                if (firstend == false) // count 처음에만 실행
                {
                    ScoreUI.gameObject.SetActive(true);
                    _archeranim.SetTrigger("DoDraw");
                    firstend = true;

                    sum += int.Parse(score._ScoreText);
                }
                
                fTickTime += Time.deltaTime;

                if (fTickTime >= 1.0f)
                {
                    archerarrow[2].SetActive(true);
                    if (!TargetTrigger.isTrigger3)
                    {
                        archerarrow[2].transform.position += new Vector3(0, 0, 0.1f);
                    }
                    else if (TargetTrigger.isTrigger3)
                    {
                        AIScoreText[2].gameObject.SetActive(true);
                    }
                }
                if (bow.count == 3) // 3회차 player turn
                {
                    count += 1; // 다음 회차로 넘김 
                    fTickTime = 0; // tick 시간 초기화
                    firstend = false; // 처음 실행 trigger 초기화
                }
            }
            if (count == 4) // 4회차
            {
                AIScoreText[2].gameObject.SetActive(true);
                playerScoreText[1].text = tempstring[1];
                playerScoreText[2].gameObject.SetActive(true);
                playerScoreText[2].text = score._ScoreText;

                if (playerScoreText[2].text != "0")
                {
                    tempstring[2] = score._ScoreText;
                }
                playerScoreText[2].text = tempstring[2];
                if (firstend == false) // count 처음에만 실행
                {
                    ScoreUI.gameObject.SetActive(true);
                    _archeranim.SetTrigger("DoDraw");
                    firstend = true;
                }
                
                fTickTime += Time.deltaTime;

                if (fTickTime >= 1.0f)
                {
                    archerarrow[3].SetActive(true);
                    if (!TargetTrigger.isTrigger4)
                    {
                        archerarrow[3].transform.position += new Vector3(0, 0, 0.1f);
                    }
                    else if (TargetTrigger.isTrigger4)
                    {
                        AIScoreText[3].gameObject.SetActive(true);
                    }
                }
                if (bow.count == 4) // 4회차 player turn
                {
                    count += 1; // 다음 회차로 넘김 
                    fTickTime = 0; // tick 시간 초기화
                    firstend = false; // 처음 실행 trigger 초기화
                }
            }
            
            if (count == 5) // 5회차
            {
                AIScoreText[3].gameObject.SetActive(true);
                playerScoreText[2].text = tempstring[2];
                playerScoreText[3].gameObject.SetActive(true);
                playerScoreText[3].text = score._ScoreText;

                if (playerScoreText[3].text != "0")
                {
                    tempstring[3] = score._ScoreText;
                }
                playerScoreText[3].text = tempstring[3];
                if (firstend == false) // count 처음에만 실행
                {
                    ScoreUI.gameObject.SetActive(true);
                    _archeranim.SetTrigger("DoDraw");
                    firstend = true;
                    
                    sum += int.Parse(score._ScoreText);
                }
                
                fTickTime += Time.deltaTime;

                if (fTickTime >= 1.0f)
                {
                    archerarrow[4].SetActive(true);
                    if (!TargetTrigger.isTrigger5)
                    {
                        archerarrow[4].transform.position += new Vector3(0, 0, 0.1f);
                    }
                    else if (TargetTrigger.isTrigger5)
                    {
                        AIScoreText[4].gameObject.SetActive(true);
                    }
                }
                if (bow.count == 5) // 5회차 player turn
                {

                    count += 1; // 다음 회차로 넘김 
                    fTickTime = 0; // tick 시간 초기화
                    firstend = false; // 처음 실행 trigger 초기화
                    
                    playerScoreText[3].gameObject.SetActive(true);
                    playerScoreText[3].text = score._ScoreText;

                }
            }

            if (count == 6) // End
            {
                AIScoreText[4].gameObject.SetActive(true);
                playerScoreText[3].text = tempstring[3];
                playerScoreText[4].gameObject.SetActive(true);
                playerScoreText[4].text = score._ScoreText;
             
                if (playerScoreText[4].text != "0")
                {
                    tempstring[4] = score._ScoreText;
                }
                playerScoreText[4].text = tempstring[4];
                
                fTickTime += Time.deltaTime;
                if (fTickTime >= 2.0f)
                {
                    sum += int.Parse(tempstring[0])
                           + int.Parse(tempstring[1]) + int.Parse(tempstring[2]) + int.Parse(tempstring[3]) +
                           int.Parse(tempstring[4]);
                    playerScoreText[5].text = sum.ToString();
                    playerScoreText[5].gameObject.SetActive(true);
                    AIScoreText[5].gameObject.SetActive(true);
                    Debug.Log("게임 종료");
                    gameover = true;
                    fTickTime = 0;
                    StartCoroutine("StampEvent");
                }
            }
        }

        if (isstampevent)
        {
            fTickTime2 += Time.deltaTime;
            if (fTickTime2 >= 4.0f)
            {
                ArrowStampUI.gameObject.SetActive(true);
                isRevert = true;
                if (isOnesound)
                {
                    UIAudioSource.clip = UIClip[2];
                    UIAudioSource.Play();
                    isOnesound = false;
                }
            }
                
            
            if (isRevert) //제자리 올려둬야함
            {
                
                fTickTime3 += Time.deltaTime;
                if (fTickTime3 >= 3.0f)
                {
                    //ArrowStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    stamp.SetActive(false);

                    isstampevent = false;
                    fTickTime3 = 0;
                }

            }
        }
        
    }

    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        
        ScoreUI.gameObject.SetActive(false);

        
            Backpack.SetActive(true);
            stamp.SetActive(true);
            UIAudioSource.clip = UIClip[1];
            UIAudioSource.Play();
            
            isstampevent = true;
        
       
    }
    
    


}
