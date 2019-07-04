using NewtonVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public NVRAttachPoint attachPoint;
    public LineRenderer lineRenderer;
    private SpringJoint joint;
    private float lineHoldDistance = 0.1f;
    private float lineHoldSpring = 200f;
    private float lineLockSpring = 40f;
    private Vector3[] posList = new Vector3[2];
    private InteractionPoint lineDrawPoint;

    public float distanceFromure(Lure fishingLure) =>
        Vector3.Distance(fishingLure.transform.position, base.gameObject.transform.position);

    private void FixedUpdate()
    {
        if(this.joint.connectedBody)
        {
            this.posList[0] = this.lineDrawPoint.transform.position;
            this.posList[1] = this.joint.connectedBody.transform.position;
            this.lineRenderer.SetPositions(this.posList);
        }
    }

    public void holdLine()
    {
        this.joint.maxDistance = this.lineHoldDistance;
        this.joint.spring = this.lineHoldSpring;
    }

    public void lockLine(float distance)
    {
        this.joint.maxDistance = distance;
        this.joint.spring = this.lineLockSpring;
    }

    public void releaseLine()
    {
        this.joint.maxDistance = 0f;
        this.joint.spring = 0.001f;
    }

    public void setLineLength(float lineLength)
    {
        this.joint.spring = this.lineLockSpring;
        this.joint.maxDistance = lineLength;
    }

    private void Start()
    {
        this.attachPoint = base.GetComponent<NVRAttachJoint>();
        this.joint = base.GetComponent<SpringJoint>();
        this.lineRenderer = base.GetComponent<LineRenderer>();
        this.lineDrawPoint = base.GetComponentInChildren<InteractionPoint>();
        this.joint.damper = 0.1f;
        this.joint.minDistance = this.lineHoldDistance;
        this.joint.maxDistance = this.lineHoldDistance;
        this.joint.spring = this.lineHoldSpring;
    }
}
