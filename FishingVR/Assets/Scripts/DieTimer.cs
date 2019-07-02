using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTimer : MonoBehaviour
{
    public float SecondsToDie = 10f;
    private float m_Timer; 

    // Start is called before the first frame update
    void Start()
    {
        this.m_Timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.m_Timer += Time.deltaTime;
        if(this.m_Timer > this.SecondsToDie)
        {
            Destroy(base.gameObject);
        }
    }
}
