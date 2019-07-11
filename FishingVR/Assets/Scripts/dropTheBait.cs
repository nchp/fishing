using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropTheBait : MonoBehaviour
{
    public GameObject baitPrefab;
    public GameObject baitPs;
    public static Vector3 baitPos = Vector3.zero;
    static int tankSize = globalFlock.tankSize;
    static int waterLevel = globalFlock.waterLevel;
    public static float Distance = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //drop the bait
        if (Input.GetKey("3"))
        {
            baitPrefab.SetActive(true);
            baitPrefab.transform.position = baitPs.transform.position;
            baitPos = baitPs.transform.position;

            Debug.Log(baitPs.transform.position);

        }
        //cancel
        if (Input.GetKey("4"))
        {
            baitPrefab.SetActive(false);
            if (Random.Range(0, 10000) < 30)
            {
                baitPos = new Vector3(Random.Range(-tankSize, tankSize),
                                      Random.Range(0, waterLevel),
                                      Random.Range(-tankSize, tankSize));
                baitPrefab.transform.position = baitPos;
            }
        }
        //pull
        if (Input.GetKey("5"))
        {
            baitPrefab.SetActive(true);
            Distance = (float)(Distance + 0.1);


        }
        //release
        if (Input.GetKey("6"))
        {
            baitPrefab.SetActive(true);
           Distance = (float)(Distance - 0.1);




        }
    }
}
