using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encoder : MonoBehaviour
{
    public GameObject en1Prefab;
    public GameObject en2Prefab;
    public static float en1Angle;
    public static float en2Angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        en1Angle = en1Prefab.transform.rotation.eulerAngles.x;
        en2Angle = en2Prefab.transform.rotation.eulerAngles.x;
    }
}
