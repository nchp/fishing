using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropTheBait : MonoBehaviour
{
    private static double prevRot = 0;

    public GameObject baitPrefab;
    public GameObject hookPrefab;
    public GameObject endPointPrefab;
    public static Vector3 baitPos = Vector3.zero;
    public static Vector3 hookPos = Vector3.zero;
    public static Vector3 endPointPos = Vector3.zero;
    static int tankSize = globalFlock.tankSize;
    static int waterLevel = globalFlock.waterLevel;
    public static float Distance = 0;
    public static int baitValue = 0;
    public static GameObject bait;
    public static int haveBait;
    public static int haveBaitPrevious;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hookPos = hookPrefab.transform.position;

        baitPos = hookPos;

        endPointPos = endPointPrefab.transform.position;

        if (Input.GetKey("3"))//enable the bait(put the bait to the hook)
        {
            if (haveBait == 0)
            {
                baitPos = dropTheBait.hookPos;
                bait = (GameObject)Instantiate(baitPrefab, baitPos, Quaternion.identity);
                haveBait = 1;
            }

            else if (haveBait == 1)
            {

                baitPrefab.transform.position = baitPos;

                baitPrefab.SetActive(true);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            print("Space key was pressed");
            hookPrefab.GetComponent<distancejoint3Dnew>().enabled = false;

        }

        if (Input.GetKeyUp("space"))
        {
            print("Space key was released");
            hookPrefab.GetComponent<distancejoint3Dnew>().enabled = true;
            Distance = Vector3.Distance(endPointPos, hookPos);
        }

        


        double deltaRot = EulerGet.EulerZ - prevRot;
        //Debug.Log(deltaRot);
        float range = (float)(((float)deltaRot) * 0.05);

        //Debug.Log(range);

            Distance = (float)(Distance + range * 0.05);
            

            if (Distance < 0)
            { Distance = 0; }


        // Distance += (float)(deltaRot * 0.001);

        prevRot = EulerGet.EulerZ;

        /*
        // pull
        if (Input.GetKey("4"))
        {

            Distance = (float)(Distance + 0.1);


        }
        //release
        if (Input.GetKey("5"))
        {

            Distance = (float)(Distance - 0.1);
        }
        */




    }
}
