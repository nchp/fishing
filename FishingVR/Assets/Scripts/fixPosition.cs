using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPosition : MonoBehaviour
{
    public GameObject pointPrefab;
    public static Vector3 fixEndPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fixEndPoint = pointPrefab.transform.position;
        this.transform.position = fixEndPoint;
    }
}
