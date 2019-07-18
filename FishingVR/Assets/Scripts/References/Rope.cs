using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    public float resolution = 0.1f;
    public float ropeDrag = 0.1f;
    public float ropeMass = 0.1f;
    public float ropeColRadius = 0.5f;
    public int segments = 10;
    public Vector3 swingAxis = new Vector3(1f, 1f, 1f);
    public float lowTwistLimit = -100f;
    public float highTwistLimit = 100f;
    public float swing1Limit = 20f;
    public Transform target;
    public Vector3[] segmentPos;
    private GameObject[] joints;
    private LineRenderer line;
    public bool rope;

    public void ResetTarget(Transform target)
    {
        this.joints = (GameObject[])null;
        Array.Clear((Array)this.segmentPos, 0, this.segmentPos.Length);
        this.rope = false;
    }

    private void Awake()
    {
        this.BuildRope();
    }

    private void Update()
    {
        if (this.rope)
            return;
        this.BuildRope();
    }

    private void LateUpdate()
    {
        if (this.rope)
        {
            for (int index = 0; index < this.segments; ++index)
            {
                if (index == 0)
                    this.line.SetPosition(index, this.transform.position);
                else if (index == this.segments - 1)
                    this.line.SetPosition(index, this.target.transform.position);
                else
                    this.line.SetPosition(index, this.joints[index].transform.position);
            }
            this.line.enabled = true;
        }
        else
            this.line.enabled = false;
    }

    private void BuildRope()
    {
        this.line = this.gameObject.GetComponent<LineRenderer>();
        this.line.SetVertexCount(this.segments);
        this.segmentPos = new Vector3[this.segments];
        this.joints = new GameObject[this.segments];
        this.segmentPos[0] = this.transform.position;
        this.segmentPos[this.segments - 1] = this.target.position;
        Vector3 vector3_1 = (this.target.position - this.transform.position) / (float)(this.segments - 1);
        for (int n = 1; n < this.segments; ++n)
        {
            Vector3 vector3_2 = vector3_1 * (float)n + this.transform.position;
            this.segmentPos[n] = vector3_2;
            this.AddJointPhysics(n);
        }
        this.target.gameObject.AddComponent<FixedJoint>().connectedBody = this.joints[this.joints.Length - 1].GetComponent<Rigidbody>();
        this.rope = true;
    }

    private void AddJointPhysics(int n)
    {
        this.joints[n] = new GameObject("Joint_" + (object)n);
        this.joints[n].transform.parent = this.transform;
        Rigidbody rigidbody = this.joints[n].AddComponent<Rigidbody>();
        SphereCollider sphereCollider = this.joints[n].AddComponent<SphereCollider>();
        CharacterJoint characterJoint = this.joints[n].AddComponent<CharacterJoint>();
        SoftJointLimit softJointLimit = new SoftJointLimit();
        softJointLimit.bounciness = 0.0f;
        softJointLimit.contactDistance = 0.01f;
        SoftJointLimitSpring jointLimitSpring = new SoftJointLimitSpring();
        jointLimitSpring.spring = 800f;
        jointLimitSpring.damper = 1f;
        characterJoint.swing1Limit = softJointLimit;
        characterJoint.swing2Limit = softJointLimit;
        characterJoint.swingLimitSpring = jointLimitSpring;
        characterJoint.twistLimitSpring = jointLimitSpring;
        characterJoint.highTwistLimit = softJointLimit;
        characterJoint.lowTwistLimit = softJointLimit;
        characterJoint.swingAxis = new Vector3(1f, 1f, 1f);
        characterJoint.axis.Set(0.0f, 0.0f, 0.0f);
        this.joints[n].transform.position = this.segmentPos[n];
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rigidbody.drag = this.ropeDrag;
        rigidbody.mass = this.ropeMass;
        sphereCollider.material.staticFriction = 1f;
        sphereCollider.material.dynamicFriction = 1f;
        sphereCollider.radius = this.ropeColRadius;
        if (n == 1)
            characterJoint.connectedBody = this.gameObject.GetComponent<Rigidbody>();
        else
            characterJoint.connectedBody = this.joints[n - 1].GetComponent<Rigidbody>();
    }

    private void DestroyRope()
    {
        this.rope = false;
        for (int index = 0; index < this.joints.Length - 1; ++index)
            UnityEngine.Object.Destroy((UnityEngine.Object)this.joints[index]);
        this.segmentPos = new Vector3[0];
        this.joints = new GameObject[0];
        this.segments = 0;
    }
}