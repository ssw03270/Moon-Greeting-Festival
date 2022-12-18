using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite : MonoBehaviour
{
    public AudioClip audio;
    public Grabbable grabbable;
    public GameObject KiteObject;
    public LineRenderer lineRenderer;
    public int segmentCount;
    public float segmentLength = 0.1f;
    public float ropeWidth = 0.1f;
    public float velocityScale = 1f;
    public Vector3 gravity = new Vector3(0, 9.8f, 0);
    public bool isRaceFinished = false;

    [Space(10f)]
    public Transform startTransform;
    private List<Segment> segments = new List<Segment>();
    private bool isFirst = true;
    public AudioSource audioSource;

    private void Reset()
    {
        TryGetComponent(out lineRenderer);
    }
    // Start is called before the first frame update
    void Awake()
    {
        Vector3 segmentPos = startTransform.position;
        for(int i = 0; i < segmentCount; i++)
        {
            segments.Add(new Segment(segmentPos));
            segmentPos.y += segmentLength;
        }
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateSegments()
    {
        for(int i = 0; i < segments.Count; i++)
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
        UpdateSegments();
        for (int i = 0; i < segmentCount; i++)
        {
            ApplyConstraint();
        }
        DrawRope();

        if(grabbable != null)
        {
            if (grabbable.BeingHeld && isFirst)
            {
                if (audio != null)
                {
                    audioSource.clip = audio;
                    audioSource.Stop();
                    audioSource.time = 0;
                    audioSource.Play();
                }
                isFirst = false;    
            }
        }
        
        if (!audioSource.isPlaying && !isFirst && !isRaceFinished)
        {
            isRaceFinished = true;
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
        for(int i = 0; i < segments.Count - 1; i++)
        {
            float distance = (segments[i].currentPos - segments[i + 1].currentPos).magnitude;
            float difference = segmentLength - distance;
            Vector3 direction = (segments[i + 1].currentPos - segments[i].currentPos).normalized;

            Vector3 movement = direction * difference;

            if(i == 0)
            {
                segments[i + 1].currentPos += movement;
            }
            else
            {
                segments[i].currentPos -= movement * 0.5f;
                segments[i + 1].currentPos += movement * 0.5f;
            }
            if(i == segments.Count - 2)
            {
                KiteObject.transform.position = segments[i + 1].currentPos;
                if(segments[i + 1].currentVel != Vector3.zero)
                {
                    KiteObject.transform.rotation = Quaternion.Slerp(KiteObject.transform.rotation, 
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
}
