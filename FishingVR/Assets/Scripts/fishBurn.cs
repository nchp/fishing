using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishBurn : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowPos = this.transform.position;

        float distance1 = Vector3.Distance(nowPos, spawnCFish.campFirePos1);
        float distance2 = Vector3.Distance(nowPos, spawnCFish.campFirePos2);
        float distance3 = Vector3.Distance(nowPos, spawnCFish.campFirePos3);
        float distance4 = Vector3.Distance(nowPos, spawnCFish.campFirePos4);
        float distance5 = Vector3.Distance(nowPos, spawnCFish.campFirePos5);

        if (distance1 < 0.5)
        {
            Destroy(this.gameObject);
            Debug.Log("burn1");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 1)
            {
                Scoring.score += 100;
            }
            else
            {
                // light off 
            }
        }

        else if (distance2 < 0.5)
        {
            Destroy(this.gameObject);
            Debug.Log("burn2");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 2)
            {
                Scoring.score += 100;
            }
            else
            {
                // light off 
            }
        }

        else if (distance3 < 0.5)
        {
            Destroy(this.gameObject);
            Debug.Log("burn3");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 3)
            {
                Scoring.score += 100;
            }
            else
            {
                // light off 
            }
        }

        else if (distance4 < 0.5)
        {
            Destroy(this.gameObject);
            Debug.Log("burn4");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 4)
            {
                Scoring.score += 100;
            }
            else
            {
                // light off 
            }
        }

        else if (distance5 < 0.5)
        {
            Destroy(this.gameObject);
            Debug.Log("burn5");
            flock.fCatch = 0;

            if (spawnCFish.categoryNum == 5)
            {
                Scoring.score += 100;
            }
            else
            {
                // light off 
            }
        }


    }
}
