using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linePointScript : MonoBehaviour
{
    public GameObject pointPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = pointPrefab.transform.position;
    }
}
