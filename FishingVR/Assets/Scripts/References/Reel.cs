using UnityEngine;

public class Reel : MonoBehaviour
{
    public float drag = 1f;
    private Quaternion previousReelAxisValueQuat = new Quaternion();
    private float reelAmount;
    private Transform reelAxisValueTransform;
    private Rigidbody reelAxisValueRigidbody;
    private ValueAxis reelValueAxis;
    public bool isReeling;

    private void Start()
    {
        this.reelValueAxis = this.gameObject.GetComponent<ValueAxis>();
        this.reelAxisValueRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (this.reelValueAxis.transform.hasChanged)
        {
            this.reelAmount = Quaternion.Angle(this.reelValueAxis.value.rotation, this.previousReelAxisValueQuat);
            if ((double)this.reelAmount > 1.0 && (double)this.reelAmount < 90.0)
                this.isReeling = true;
        }
        else
            this.isReeling = false;
        this.previousReelAxisValueQuat.Set(this.reelValueAxis.value.rotation.x, this.reelValueAxis.value.rotation.y, this.reelValueAxis.value.rotation.z, this.reelValueAxis.value.rotation.w);
    }

    public float getReelByDistance()
    {
        return this.reelAmount * this.drag;
    }

    public Rigidbody getReelAxisBody()
    {
        return this.reelAxisValueRigidbody;
    }

    public void showReel(bool shouldShow)
    {
    }

    private void Update()
    {
    }
}