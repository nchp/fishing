using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishBurn : MonoBehaviour
{

    public static int numRight;



    // Update is called once per frame
    void Update()
    {
    

        Vector3 nowPos = this.transform.position;

        float distance1 = Vector3.Distance(nowPos, spawnCFish.campFirePos1);
        float distance2 = Vector3.Distance(nowPos, spawnCFish.campFirePos2);
        float distance3 = Vector3.Distance(nowPos, spawnCFish.campFirePos3);
        float distance4 = Vector3.Distance(nowPos, spawnCFish.campFirePos4);
        float distance5 = Vector3.Distance(nowPos, spawnCFish.campFirePos5);
        float distance6 = Vector3.Distance(nowPos, spawnCFish.bucketPos);

        if ((distance1 < 0.5) && (spawnCFish.wrong1 == 0))
        {
            Destroy(this.gameObject);
            Debug.Log("burn1");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 1)
            {
                numRight += 1;  
            }
            else
            {
                spawnCFish.wrong1 = 1;
                Debug.Log("f1 off");

                // light off 
            }
        }

        else if ((distance2 < 0.5) && (spawnCFish.wrong2 == 0))
        {
            Destroy(this.gameObject);
            Debug.Log("burn2");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 2)
            {
                numRight += 1;
            }
            else
            {
                spawnCFish.wrong2 = 1;
                Debug.Log("f2 off");
                // light off 
            }
        }

        else if ((distance3 < 0.5) && (spawnCFish.wrong3 == 0))
        {
            Destroy(this.gameObject);
            Debug.Log("burn3");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 3)
            {
                numRight += 1;
            }
            else
            {
                spawnCFish.wrong3 = 1;
                Debug.Log("f3 off");
                // light off 
            }
        }

        else if ((distance4 < 0.5) && (spawnCFish.wrong4 == 0))
        {
            Destroy(this.gameObject);
            Debug.Log("burn4");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 4)
            {
                numRight += 1;
            }
            else
            {
                spawnCFish.wrong4 = 1;
                Debug.Log("f4 off");
                // light off 
            }
        }

        else if ((distance5 < 0.5) && (spawnCFish.wrong5 == 0))
        {
            Destroy(this.gameObject);
            Debug.Log("burn5");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 5)
            {
                numRight += 1;
            }
            else
            {
                spawnCFish.wrong5 = 1;
                Debug.Log("f5 off");
                // light off 
            }
        }

        else if (distance6 < 0.5)
        {
            Destroy(this.gameObject);
            Debug.Log("bucket");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 3)
            {
                numRight += 0;
            }

        }


    }
}
