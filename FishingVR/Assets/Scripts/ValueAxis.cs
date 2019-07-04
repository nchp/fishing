using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueAxis : MonoBehaviour
{

    public Transform value;

    private void FixedUpdate()
    {
        this.value = base.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.value = base.transform;
    }
}
