using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{

    public bool isHooked;
    public bool hasBait;
    public FishFood attachedBait;

    public void addBait(FishFood bait)
    {
        if(!this.hasBait && bait)
        {
            bait.isAttachedToPlayerLure == true;
            bait.attachedPlayerLure = this;
            bait.GetComponentInParent<Transform>().parent.parent = base.gameObject.transform;
            bait.transform.localPosition.Set(0f, 0f, 0f);
            FixedJoint joint = bait.transform.parent.gameObject.AddComponent<FixedJoint>();
            joint.anchor.Set(0f, 0f, 0f);
            joint.connectedBody = base.gameObject.GetComponent<RigidBody>();
            this.hasBait = true;
            this.attachedBait = bait;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!this.hasBait || !this.attachedBait)
        {
            FishFodd componentInChildren = collision.collider.gameObject.GetComponentInChildren<FishFood>();
            if(componentInChildren)
            {
                this.addBait(componentInChildren);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.isHooked = false;
        this.hasBait = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
