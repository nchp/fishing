using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCFish : MonoBehaviour
{
    public static int wordNum;
    public static int categoryNum;
    public static int amountOfWords;
    public GameObject CFishPrefab;

    public GameObject campFirePrefab1;
    public GameObject campFirePrefab2;
    public GameObject campFirePrefab3;
    public GameObject campFirePrefab4;
    public GameObject campFirePrefab5;

    public static float distance1;
    public static float distance2;
    public static float distance3;
    public static float distance4;
    public static float distance5;

    public static Vector3 campFirePos1;
    public static Vector3 campFirePos2;
    public static Vector3 campFirePos3;
    public static Vector3 campFirePos4;
    public static Vector3 campFirePos5;

    // Start is called before the first frame update
    void Start()
    {
        amountOfWords = 10;

    }

    // Update is called once per frame
    void Update()
    {

        //for fishBurn *can't put prefab in prefab which isn't in the scence*
        campFirePos1 = campFirePrefab1.transform.position;
        campFirePos2 = campFirePrefab2.transform.position;
        campFirePos3 = campFirePrefab3.transform.position;
        campFirePos4 = campFirePrefab4.transform.position;
        campFirePos5 = campFirePrefab5.transform.position;


        Vector3 pos = dropTheBait.hookPos;

        if (flock.fCatch == 1)
        {
            
            Instantiate(CFishPrefab, pos, Quaternion.identity);

            categoryNum = Random.Range(1, 5);
            categoryNum = categoryNum * 100;
            wordNum = categoryNum + Random.Range(1, amountOfWords);
            Debug.Log(wordNum);

            flock.fCatch = 2;
        }

        if (flock.fCatch == 2 )
        {
            CFishPrefab.transform.position = pos;
        }

    }
}
