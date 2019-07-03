using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishActivityState
{
    FishActivityStateSwimmingAround,
    FishActivityStatePursuingFood,
    FishActivityStateEatingFood,
    FishActivityStateHooked,
    FishActivityStateCaught
}

public class Fish : MonoBehaviour
{
    public float fishSpeed = 1f;
    public float waterHeight = 0.8f;
    public int stomachSize = 1;
    private Transform prevLocation;
    private Rigidbody fishRigidBody;
    private SpringJoint mouthAttachJoint;
    private Rigidbody bobberRigidBody;
    private Lure playerLure;
    private FishFood foodBeingPursued;
    private bool isSwimmingTowardFood;
    private bool isHooked;
    private bool isCaught;
    private int stomachCount;
    private FishActivityState activityState;

    private Lure biteLure(Lure lure)
    {
        lure.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0x3e8f, -1000f, 0f));
        lure.attachedBait = null;
        lure.isHooked = true;
        lure.hasBait = false;
        this.mouthAttachJoint = base.gameObject.AddComponent<SpringJoint>();
        this.mouthAttachJoint.connectedBody = lure.GetComponent<Rigidbody>();
        this.mouthAttachJoint.anchor = base.gameObject.GetComponentInChildren<InteractionPoint>().transform.localPosition;
        this.mouthAttachJoint.spring = 0x3e8f;
        this.mouthAttachJoint.damper = 0.1f;
        this.mouthAttachJoint.maxDistance = 0.001f;
        this.mouthAttachJoint.minDistance = 0.001f;
        return lure;
    }

    private void eatFood(FishFood food)
    {
        if(this.isHungry())
        {
            bool flag = food.bite();
            Lure componentInParent = this.foodBeingPursued.GetComponentInParent<Lure>();
            if(componentInParent)
            {
                Lure lure2 = this.biteLure(componentInParent);
                if(lure2)
                {
                    this.playerLure = lure2;
                    this.setActivityState(FishActivityState.FishActivityStateHooked);
                }
            }
            else
            {
                this.stomachCount++;
                if(this.isHungry())
                {
                    this.setActivityState(FishActivityState.FishActivityStatePursuingFood);
                }
                else
                {
                    this.setActivityState(FishActivityState.FishActivityStateSwimmingAround);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float num = this.fishSpeed * Time.deltaTime;
        if(this.activityState == FishActivityState.FishActivityStateSwimmingAround)
        {
            this.swimAround();
        }
    }

    private bool isHungry() =>
        (this.stomachCount < this.stomachSize);

    private void OntriggerEnter(Collider collider)
    {
        if(this.activityState == FishActivityState.FishActivityStateSwimmingAround)
        {
            if(collider.name == "fishFood-trigger") {
                FishFood component = collider.gameObject.GetComponent<FishFood>();
                if(component)
                {
                    this.swimTowardFood(component);
                }
            }

            if(collider.name == "fishFence-trigger")
            {
                base.gameObject.transform.Rotate(new Vector3(0f,160f,0f));
            }
        }

        if((this.activityState == FishActivityState.FishActivityStateHooked) && (collider.name == "fishLanding-trigger"))
        {
            this.setActivityState(FishActivityState.FishActivityStateCaught);
        }

        if((this.activityState == FishActivityState.FishActivityStateCaught) && (collider.name == "water"))
        {
            this.setActivityState(FishActivityState.FishActivityStateSwimmingAround);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if((this.activityState == FishActivityState.FishActivityStateSwimmingAround) && (collider.name == "water"))
        {
            base.gameObject.transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        else if ((this.activityState == FishActivityState.FishActivityStatePursuingFood) && (collider.name == "fishFood-trigger"))
        {
            this.setActivityState(FishActivityState.FishActivityStateSwimmingAround);
        }
        else
        {
            if(this.activityState == FishActivityState.FishActivityStateHooked)
            {

            }
            if (this.activityState == FishActivityState.FishActivityStateEatingFood)
            {

            }
        }
    }

    private void setActivityState(FishActivityState state)
    {
        this.activityState = state;
        switch(state)
        {
            case FishActivityState.FishActivityStateSwimmingAround:
                this.isHooked = false;
                this.isCaught = false;
                this.isSwimmingTowardFood = false;
                this.foodBeingPursued = null;
                this.playerLure = null;
                break;

            case FishActivityState.FishActivityStatePursuingFood:
                this.isHooked = false;
                this.isCaught = false;
                this.isSwimmingTowardFood = true;
                break;

            case FishActivityState.FishActivityStateEatingFood:
                this.isHooked = false;
                this.isCaught = false;
                this.isSwimmingTowardFood = true;
                break;

            case FishActivityState.FishActivityStateHooked:
                this.isHooked = true;
                this.isCaught = false;
                this.isSwimmingTowardFood = false;
                break;

            case FishActivityState.FishActivityStateCaught:
                this.isHooked = false;
                this.isCaught = true;
                this.isSwimmingTowardFood = false;
                this.foodBeingPursued = null;
                this.playerLure.isHooked = false;
                this.playerLure = null;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.fishRigidBody = base.gameObject.GetComponent<Rigidbody>();
        this.prevLocation = base.gameObject.transform;
        this.setActivityState(FishActivityState.FishActivityStateSwimmingAround);
    }

    private void swimAround()
    {
        if(this.activityState != FishActivityState.FishActivityStateSwimmingAround)
        {
            this.setActivityState(FishActivityState.FishActivityStateSwimmingAround);
        }
        if(Vector3.Distance(this.prevLocation.position, base.gameObject.transform.position) < 0.1)
        {
            base.gameObject.transform.Rotate(new Vector3(0f, 0.1f, 0f));
        }
        this.fishRigidBody.AddForce(new Vector3(0f, -50f, 0f));
        this.fishRigidBody.rotation.Set(this.fishRigidBody.rotation.x, this.fishRigidBody.rotation.y, 0f, this.fishRigidBody.rotation.w);
    }

    private void swimTowardFood(FishFood food)
    {
        this.setActivityState(FishActivityState.FishActivityStatePursuingFood);
        base.gameObject.transform.LookAt(food.transform.position);
        this.fishRigidBody.AddForce(base.gameObject.transform.forward * this.fishSpeed);
        this.foodBeingPursued = food;
    }
}