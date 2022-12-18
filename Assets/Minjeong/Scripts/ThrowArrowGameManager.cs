using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThrowArrowGameManager : MonoBehaviour
{ 
    public int count = 0; // count는 총 5회
    public GameObject TriggerBox; // mission trigger
    public GameObject TargetTrigger; // Cylinder
    public GameObject[] archerarrow; // 상대 arrow 배열
    public GameObject Archer;
    
    //triger
    private Trigger _trigger;
    private TargetTrigger _targetTrigger;

    private bool gameover;

    private float fTickTime;
    private bool firstend = false;
    private Animator _archeranim;
    // Start is called before the first frame update
    void Start()
    {
        _trigger = TriggerBox.GetComponent<Trigger>();
        _targetTrigger = TargetTrigger.GetComponent<TargetTrigger>();
        // archer arrow visible
        archerarrow[0].SetActive(false);
        archerarrow[1].SetActive(false);
        archerarrow[2].SetActive(false);
        archerarrow[3].SetActive(false);
        archerarrow[4].SetActive(false);
        
        //archer animation
        _archeranim = Archer.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            if (_trigger.isTrigger && count == 0) //first trigger, 게임 시작
            {
                Debug.Log("hello1");
                // (+UI 활성화)
                fTickTime += Time.deltaTime;
                
                if (fTickTime >= 2.0f && firstend == false) // 처음에만 애님 실행
                {
                    Debug.Log("hello2");
                    // 2초 뒤에 실행
                    _archeranim.SetTrigger("DoDraw");
                    archerarrow[0].SetActive(true);
                    fTickTime = 0;
                    firstend = true;
                }
                
                if (!_targetTrigger.isTrigger)
                {
                    Debug.Log("false");
                    archerarrow[0].transform.position += new Vector3(0, 0, 0.01f);
                }
                
            }
        }
        
    }
}
