using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWheel : MonoBehaviour
{
    public GameObject FireWheelObject;
    public Grabbable grabbable;
    public LineRenderer lineRenderer;

    public Material night;
    public Material day;

    public int segmentCount;
    public float segmentLength = 0.1f;
    public float ropeWidth = 0.1f;
    public float velocityScale = 1f;
    public Vector3 gravity = new Vector3(0, 9.8f, 0);

    [Space(10f)]
    public Transform startTransform;
    private List<Segment> segments = new List<Segment>();
    private bool isFirst = true;
    
    //Stamp
    public Trigger FireWheelTrigger;
    public Canvas FireWheelStampUI;
    public Canvas FireWheelMissionUI;
    public GameObject Backpack;
    public GameObject FireWheeltstamp;
    private bool isstampevent;
    private bool isRevert;
    private float fTickTime;
    private float fTickTime2;
    private bool isFirstEnd;
    private int count;
    public AudioClip[] UIClip;
    public AudioSource UIAudioSource;
    private bool isfirstsound = true;
    private bool isNightTry = false;
    private bool isOnesound = true;
    private void Reset()
    {
        TryGetComponent(out lineRenderer);
    }
    // Start is called before the first frame update
    void Awake()
    {
        Vector3 segmentPos = startTransform.position;
        for (int i = 0; i < segmentCount; i++)
        {
            segments.Add(new Segment(segmentPos));
            segmentPos.y += segmentLength;
        }
    }

    void UpdateSegments()
    {
        for (int i = 0; i < segments.Count; i++)
        {
            segments[i].currentVel = segments[i].currentPos - segments[i].previousPos;
            segments[i].currentVel /= velocityScale;
            segments[i].previousPos = segments[i].currentPos;
            segments[i].currentPos += gravity * Time.fixedDeltaTime * Time.fixedDeltaTime;
            segments[i].currentPos += segments[i].currentVel;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (FireWheelTrigger.isTrigger && count == 0) //first trigger, 게임 시작
        {
            // (+게임 설명 UI 활성화)
            FireWheelMissionUI.gameObject.SetActive(true);
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
                FireWheelMissionUI.gameObject.SetActive(false);
                fTickTime = 0;
                count += 1;
            }
        }
        UpdateSegments();
        for (int i = 0; i < segmentCount; i++)
        {
            ApplyConstraint();
        }
        DrawRope();

        if (grabbable != null)
        {
            if (grabbable.BeingHeld)
            {
                RenderSettings.skybox = night;
                isNightTry = true;
            }
            else
            {
                RenderSettings.skybox = day;
                if (!isFirstEnd && isNightTry)
                {
                    isFirstEnd = true;
                    StartCoroutine("StampEvent");
                }
                
            }
        }
        
        if (isstampevent)
        {
            fTickTime += Time.deltaTime;
            if (fTickTime >= 4.0f)
            {
                FireWheelStampUI.gameObject.SetActive(true);
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
                    //FireWheelStampUI.gameObject.SetActive(false);
                    Backpack.SetActive(false);
                    FireWheeltstamp.SetActive(false);

                    isstampevent = false;
                    fTickTime2 = 0;
                }

            }
        }
    }

    private void DrawRope()
    {
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;

        Vector3[] segmentPositions = new Vector3[segments.Count];
        for (int i = 0; i < segments.Count; i++)
        {
            segmentPositions[i] = segments[i].currentPos;
        }

        lineRenderer.positionCount = segmentPositions.Length;
        lineRenderer.SetPositions(segmentPositions);
    }
    private void ApplyConstraint()
    {
        segments[0].currentPos = startTransform.position;
        for (int i = 0; i < segments.Count - 1; i++)
        {
            float distance = (segments[i].currentPos - segments[i + 1].currentPos).magnitude;
            float difference = segmentLength - distance;
            Vector3 direction = (segments[i + 1].currentPos - segments[i].currentPos).normalized;

            Vector3 movement = direction * difference;

            if (i == 0)
            {
                segments[i + 1].currentPos += movement;
            }
            else
            {
                segments[i].currentPos -= movement * 0.5f;
                segments[i + 1].currentPos += movement * 0.5f;
            }
            if (i == segments.Count - 2)
            {
                FireWheelObject.transform.position = segments[i + 1].currentPos;
                if (segments[i + 1].currentVel != Vector3.zero)
                {
                    FireWheelObject.transform.rotation = Quaternion.Slerp(FireWheelObject.transform.rotation,
                        Quaternion.LookRotation(segments[i + 1].currentPos - segments[i + 1].previousPos)
                        * Quaternion.Euler(new Vector3(0, 90, 0)), Time.fixedDeltaTime);
                }
            }
        }
    }
    public class Segment
    {
        public Vector3 previousPos;
        public Vector3 currentPos;
        public Vector3 currentVel;

        public Segment(Vector3 pos)
        {
            previousPos = pos;
            currentPos = pos;
            currentVel = Vector3.zero;
        }
    }
    
    IEnumerator StampEvent() // stamp event
    {
        yield return new WaitForSeconds(2.0f);
        
        
        Backpack.SetActive(true);
        FireWheeltstamp.SetActive(true);
        UIAudioSource.clip = UIClip[1];
        UIAudioSource.Play();
    
        isstampevent = true;
    }
}
