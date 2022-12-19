using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamulnoriManager : MonoBehaviour
{
    //Stamp
    public Trigger SamulnoriTrigger;
    public Canvas SamulnoriStampUI;
    public Canvas RSamulnoriMissionUI;
    public GameObject Backpack;
    public GameObject Samulnoristamp;
    private bool isstampevent;
    private bool isRevert;
    private float fTickTime;
    private float fTickTime2;
    private int count;
    public GameObject[] Grabble;
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;
    private bool isfirstsound = true;
    private bool isOnesound = true;

    private float EndTime;
    private bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd)
        {
            if (SamulnoriTrigger.isTrigger && count == 0) //first trigger, 게임 시작
            {
                // (+게임 설명 UI 활성화)
                RSamulnoriMissionUI.gameObject.SetActive(true);
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
                    RSamulnoriMissionUI.gameObject.SetActive(false);
                    fTickTime = 0;
                    count += 1;
                }
            }

            if (Grabble[0].GetComponent<Grabbable>().BeingHeld)
            {
                if (count == 1)
                {
                    count += 1;
                }
            }
            else
            {
                if (count == 2)
                {
                    count += 1;
                }
            }
            
            EndTime += Time.deltaTime;
            if (SamulnoriTrigger.isTrigger && count >= 3)
            {
                gameEnd = true;
                StartCoroutine("StampEvent");
            }
        }
        
        
        if (isstampevent)
        {
            fTickTime += Time.deltaTime;
            if (fTickTime >= 4.0f)
            {
                SamulnoriStampUI.gameObject.SetActive(true);
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
                    //SamulnoriStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    Samulnoristamp.SetActive(false);

                    isstampevent = false;
                    fTickTime2 = 0;
                }

            }
        }
    }
    
    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        Grabble[0].SetActive(false);
        Grabble[1].SetActive(false);
        Grabble[2].SetActive(false);
        Grabble[3].SetActive(false);
        Grabble[4].SetActive(false);
        UIAudioSource.clip = UIClip[1];
        UIAudioSource.Play();
        Backpack.SetActive(true);
        Samulnoristamp.SetActive(true);
        
        isstampevent = true;
    }
    
}
