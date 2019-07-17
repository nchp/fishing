using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baitCode : MonoBehaviour

{

    public static int haveBait;
    public static int baitEnable;
    public static int baitP1;
    public static int baitP2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = dropTheBait.hookPos;
        if(this.transform.position.y < globalFlock.waterLevel)
        {
            baitEnable = 1;
            
        }

        else if (this.transform.position.y > globalFlock.waterLevel)
        {
            baitEnable = 0;
        }

       if (flock.fCatch == 1)
        {
            this.gameObject.SetActive(false);
        }

    }
}
