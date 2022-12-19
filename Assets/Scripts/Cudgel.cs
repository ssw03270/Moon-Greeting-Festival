using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cudgel : MonoBehaviour
{
    public Grabbable grabbable;
    public CudgelChest cudgelChest;
    public AudioClip audioStart;
    public AudioClip audioEnd;
    private AudioSource audioSource;

    //Stamp
    public Trigger CudgelTrigger;
    public Canvas CudgelStampUI;
    public Canvas CudgelMissionUI;
    public GameObject Backpack;
    public GameObject Cudgelstamp;
    public bool isstampevent;
    private bool isRevert;
    private float fTickTime;
    private float fTickTime2;
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;

    private bool isFirst = true;
    private bool isfirstsound = true;
    private bool isOnesound = true;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CudgelTrigger.isTrigger && count == 0) //first trigger, 게임 시작
        {
            // (+게임 설명 UI 활성화)
            CudgelMissionUI.gameObject.SetActive(true);

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
                CudgelMissionUI.gameObject.SetActive(false);
                fTickTime = 0;
                count += 1;
            }
        }
        if (grabbable != null)
        {
            if (grabbable.BeingHeld && isFirst)
            {
                audioSource.clip = audioStart;
                audioSource.Stop();
                audioSource.time = 0;
                audioSource.Play();
                isFirst = false;
            }
        }

        if(cudgelChest.score == 5)
        {
            audioSource.clip = audioEnd;
            audioSource.Stop();
            audioSource.time = 0;
            audioSource.Play();
            cudgelChest.score = -999;
            
            StartCoroutine("StampEvent");
        }
        
        if (isstampevent)
        {
            fTickTime += Time.deltaTime;
            
            if (fTickTime >= 4.0f)
            {
                CudgelStampUI.gameObject.SetActive(true);
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
                    //CudgelStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    Cudgelstamp.SetActive(false);

                    isstampevent = false;
                    fTickTime2 = 0;
                }
            }
        }
    }
    
    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        
        grabbable.gameObject.SetActive(false);
        Backpack.SetActive(true);
        Cudgelstamp.SetActive(true);
        UIAudioSource.clip = UIClip[1];
        UIAudioSource.Play();
        isstampevent = true;
    }
}
