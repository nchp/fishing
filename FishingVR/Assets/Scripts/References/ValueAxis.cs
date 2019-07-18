using UnityEngine;

public class ValueAxis : MonoBehaviour
{
    public Transform value;

    private void Start()
    {
        this.value = this.transform;
    }

    private void Fixedupdate()
    {
        this.value = this.transform;
    }
}