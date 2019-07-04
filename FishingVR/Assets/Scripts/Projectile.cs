using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float travelDistance = speed * Time.deltaTime;
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, travelDistance))
        {
            travelDistance = hit.distance;
            this.transform.position += this.transform.forward * travelDistance;
            this.transform.parent = hit.transform;
            Destroy(this);
        }
        else
        {
            this.transform.position += this.transform.forward * travelDistance;
        }
    }
}
