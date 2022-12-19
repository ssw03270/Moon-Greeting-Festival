using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoScoring : MonoBehaviour
{
    public int score;
    
    //Stamp
    public Trigger TuhoTrigger;
    public Canvas TuhoStampUI;
    public Canvas TuhoMissionUI;
    public GameObject Backpack;
    public GameObject Tuhotstamp;
    private bool isstampevent;
    private bool isRevert;
    private float fTickTime;
    private float fTickTime2;
    private int count;
    
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;
    private bool isfirstsound = true;
    private bool isOnesound = true;

    public GameObject[] Tuho;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TuhoTrigger.isTrigger && count == 0) //first trigger, 게임 시작
        {
            // (+게임 설명 UI 활성화)
            TuhoMissionUI.gameObject.SetActive(true);
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
                TuhoMissionUI.gameObject.SetActive(false);
                fTickTime = 0;
                count += 1;
            }
        }
        
        if (isstampevent)
        {
            fTickTime += Time.deltaTime;
            if (fTickTime >= 4.0f)
            {
                TuhoStampUI.gameObject.SetActive(true);
                isRevert = true;
                if (isOnesound)
                {
                    UIAudioSource.clip = UIClip[2];
                    UIAudioSource.Play();
                    isOnesound = false;
                }

            }
            
            if (isRevert) 
            {
                fTickTime2 += Time.deltaTime;
                if (fTickTime2 >= 3.0f)
                {
                    //TuhoStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    Tuhotstamp.SetActive(false);

                    isstampevent = false;
                    fTickTime2 = 0;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arrow")
        {
            score += 1;

            if(score >= 3)
            {
                print("clear");
                StartCoroutine("StampEvent");
            }
        }
    }
    
    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        
        
        Backpack.SetActive(true);
        Tuhotstamp.SetActive(true);
        UIAudioSource.clip = UIClip[1];
        UIAudioSource.Play();
        // + tuho 오브젝트 다 삭제해야함
        
        isstampevent = true;
    }
}
