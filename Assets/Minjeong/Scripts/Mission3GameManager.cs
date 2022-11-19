using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission3GameManager : MonoBehaviour
{
    public GameObject Bread;
    public GameObject Cake;
    public GameObject Pie;
    public GameObject Mission3UI;
    public GameObject TriggerBox;
    public GameObject Blanket;

    private Trigger _trigger;
    private HintUI _hintUI;
    private BlanketCollision _blanketCollision;
    private int levelcount = 0;

    private int count = 0;

    private bool isGameEnd;
    // Start is called before the first frame update
    void Start()
    {
        _trigger = TriggerBox.GetComponent<Trigger>();
        _hintUI = Mission3UI.GetComponentInChildren<HintUI>();
        _blanketCollision = Blanket.GetComponent<BlanketCollision>();
        isGameEnd = false;
    }

    private void Update()
    {
        if (!isGameEnd)
        {
            if (count == 0 && _trigger.isTrigger)
            {
                count += 1;
                
                StartCoroutine("BreadMission");
            }

            if (_blanketCollision.isblanketcollision && levelcount == 0) // 레벨 0에 대해서 충돌이 있을 때
            {
                if (_blanketCollision.isBread)
                {
                    Debug.Log("1단계 성공");
                    _hintUI.BreadHide();
                    StartCoroutine("CakeMission");
                }
                else
                {
                    Debug.Log("잘못된 재료");
                }
            }
            
            if (_blanketCollision.isblanketcollision && levelcount == 1) // 레벨 1에 대해서 충돌이 있을 때
            {
                if (_blanketCollision.isCake)
                {
                    Debug.Log("2단계 성공");
                    _hintUI.CakeHide();
                    StartCoroutine("PieMission");
                }
                else
                {
                    Debug.Log("잘못된 재료");
                }
            }
            
            if (_blanketCollision.isblanketcollision && levelcount == 2) // 레벨 2에 대해서 충돌이 있을 때
            {
                if (_blanketCollision.isPie)
                {
                    Debug.Log("3단계 성공");
                    _hintUI.PieHide();
                    levelcount += 1;
                }
                else
                {
                    Debug.Log("잘못된 재료");
                }
            }

            if (levelcount == 3)
            {
                Debug.Log("End");
            }
        }
    }
    
    IEnumerator BreadMission()
    {
        yield return new WaitForSeconds(3f);
        
        _hintUI.BreadShow();
    }
    
    IEnumerator CakeMission()
    {
        levelcount += 1;
        yield return new WaitForSeconds(3f);
        _hintUI.CakeShow();
    }
    
    IEnumerator PieMission()
    {
        levelcount += 1;
        yield return new WaitForSeconds(3f);
        _hintUI.PieShow();
    }
    
}
