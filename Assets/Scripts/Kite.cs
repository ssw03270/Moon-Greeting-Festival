using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite : MonoBehaviour
{
    public GameObject KiteObject;
    public LineRenderer lineRenderer;
    public int segmentCount;
    public float segmentLength = 0.1f;
    public float ropeWidth = 0.1f;
    public Vector3 gravity = new Vector3(0, 9.8f, 0);

    [Space(10f)]
    public Transform startTransform;
    private List<Segment> segments = new List<Segment>();

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
    }

    void UpdateSegments()
    {
        for(int i = 0; i < segments.Count; i++)
        {
            segments[i].currentVel = segments[i].currentPos - segments[i].previousPos;
            segments[i].currentVel /= 2f;
            segments[i].previousPos = segments[i].currentPos;
            segments[i].currentPos += gravity * Time.fixedDeltaTime * Time.fixedDeltaTime;
            segments[i].currentPos += segments[i].currentVel;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateSegments();
        for(int i = 0; i < segmentCount; i++)
        {
            ApplyConstraint();
        }
        DrawRope();
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
                    KiteObject.transform.rotation = Quaternion.LookRotation(segments[i + 1].currentPos - segments[i + 1].previousPos);
                    KiteObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));
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
