using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RiceChestVideoPlayer : MonoBehaviour
{
    public GameObject video;
    private VideoPlayer videoPlayer;
    
    //Stamp
    public Trigger RiceChestTrigger;
    public Canvas RiceChestStampUI;
    public Canvas RiceChestMissionUI;
    public GameObject Backpack;
    public GameObject RiceCheststamp;
    private bool isstampevent;
    private bool isRevert;
    private float fTickTime;
    private float fTickTime2;
    private int count;
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;
    private bool isfirstsound = true;
    private bool isOnesound = true;
    
    void Start()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RiceChestTrigger.isTrigger && count == 0) //first trigger, 게임 시작
        {
            // (+게임 설명 UI 활성화)
            RiceChestMissionUI.gameObject.SetActive(true);
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
                RiceChestMissionUI.gameObject.SetActive(false);
                fTickTime = 0;
                count += 1;
            }
        }
        
        if (isstampevent)
        {
            fTickTime += Time.deltaTime;
            if (fTickTime >= 4.0f)
            {
                RiceChestStampUI.gameObject.SetActive(true);
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
                    //RiceChestStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    RiceCheststamp.SetActive(false);

                    isstampevent = false;
                    fTickTime2 = 0;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            videoPlayer.Play();
            print("abcd");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            videoPlayer.Stop();

            StartCoroutine("StampEvent");
        }
    }
    
    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        
        Backpack.SetActive(true);
        RiceCheststamp.SetActive(true);
        UIAudioSource.clip = UIClip[1];
        UIAudioSource.Play();
        isstampevent = true;
    }
}
