using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public float drag = 1f;
    private float reelAmount;
    private Transform reelAxisValueTransform;
    private Quaternion previousReelAxisValueQuat;
    private Rigidbody reelAxisValueRigidbody;
    private ValueAxis reelValueAxis;
    public bool isReeling;

    public Reel()
    {
        Quaternion quaternion = new Quaternion();
        this.previousReelAxisValueQuat = quaternion;
    }

    private void FixedUpdate()
    {
        if(!this.reelValueAxis.transform.hasChanged)
        {
            this.isReeling = false;
        }
        else
        {
            this.reelAmount = Quaternion.Angle(this.reelValueAxis.value.rotation, this.previousReelAxisValueQuat);
            if((this.reelAmount > 1f) && (this.reelAmount < 90f))
            {
                this.isReeling = true;
            }
        }
        this.previousReelAxisValueQuat.Set(this.reelValueAxis.value.rotation.x, this.reelValueAxis.value.rotation.y, this.reelValueAxis.value.rotation.z, this.reelValueAxis.value.rotation.w);
    }

    public Rigidbody getReelAxisBody() =>
        this.reelAxisValueRigidbody;

    public float getReelByDistance() =>
        (this.reelAmount * this.drag);

    public void showReel(bool shouldShow)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.reelValueAxis = base.gameObject.GetComponentInChildren<ValueAxis>();
        this.reelAxisValueRigidbody = base.gameObject.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
