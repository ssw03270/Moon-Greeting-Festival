using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteRacePoint : MonoBehaviour
{
    public GameObject[] Fire;
    public AudioSource background;
    public Kite kite;
    
    //Stamp
    public Trigger KiteTrigger;
    public Canvas  KiteStampUI;
    public Canvas KiteMissionUI;
    public GameObject Backpack;
    public GameObject Kitetstamp;
    private bool isstampevent;
    private bool isRevert;
    private float fTickTime;
    private float fTickTime2;
    private int count;

    
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;
    private bool isfirstsound = true;
    private bool isOnesound = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KiteTrigger.isTrigger && count == 0) //first trigger, 게임 시작
        {
            // (+게임 설명 UI 활성화)
            KiteMissionUI.gameObject.SetActive(true);
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
                KiteMissionUI.gameObject.SetActive(false);
                fTickTime = 0;
                count += 1;
            }
        }
        
        if (isstampevent)
        {
            fTickTime += Time.deltaTime;
            if (fTickTime >= 4.0f)
            {
                KiteStampUI.gameObject.SetActive(true);
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
                    //KiteStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    Kitetstamp.SetActive(false);

                    for (int i = 0; i < Fire.Length; i++)
                    {
                        Fire[i].SetActive(true);
                    }

                    isstampevent = false;
                    fTickTime2 = 0;
                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!kite.isRaceFinished && other.tag == "Player")
        {
            kite.audioSource.Stop();
            print("goal");
            background.Play();

            StartCoroutine("StampEvent");
            
        }
    }
    
    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        
        kite.gameObject.SetActive(false);
        Backpack.SetActive(true);
        Kitetstamp.SetActive(true);
        UIAudioSource.clip = UIClip[1];
        UIAudioSource.Play();
    
        isstampevent = true;
    }
}
