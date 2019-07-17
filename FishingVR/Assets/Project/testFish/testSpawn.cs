using UnityEngine;
using System.Collections;

public class testSpawn : MonoBehaviour
{

    public GameObject spawnPrefab; //get prefab from outside
    public static int worldSize = 300; //can edit tank size from outside
    public static int worldSizeTemp;
    public static int waterLevel = 10;
    public static int islandSize = 150;
    public static int numSpawn = 1; //can edit numFish outside
    public static Vector3 spawnPos = Vector3.zero;
    public static GameObject[] allSpawn = new GameObject[numSpawn];
    //public GameObject goalPrefab;
    //public GameObject ndGoalPrefab;
    //Vector3 goalPos = globalFlock.goalPos;
    //Vector3 ndGoalPos = globalFlock.ndGoalPos;
    public static Vector3 goalPos = Vector3.zero;
    public static Vector3 ndGoalPos = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        worldSizeTemp = worldSize - islandSize;

        for (int i = 0; i < numSpawn; i++)    //loop for spawning fish randomly

        {
            Vector3 pos = new Vector3(Random.Range(-worldSize, worldSize),
                                      Random.Range(0, waterLevel),//y = water level
                                      Random.Range(-worldSize, worldSize));
            while (Vector3.Distance(pos, Vector3.zero) <= 150)
            {
                pos = new Vector3(Random.Range(-worldSize, worldSize),
                                         Random.Range(0, waterLevel),//y = water level
                                         Random.Range(-worldSize, worldSize));
            }
            allSpawn[i] = (GameObject)Instantiate(spawnPrefab, pos, Quaternion.identity);
            spawnPos = new Vector3(Random.Range(-worldSize, worldSize),
                                      Random.Range(0, waterLevel),
                                      Random.Range(-worldSize, worldSize));
            while (Vector3.Distance(spawnPos, Vector3.zero) <= 150)
            {
                spawnPos = new Vector3(Random.Range(-worldSize, worldSize),
                                      Random.Range(0, waterLevel),
                                      Random.Range(-worldSize, worldSize));

            }

        }

    }




    // Update is called once per frame
    void Update()//changing the goalpos of the fish

    {

        /*
        if (Random.Range(0, 10000) < 100)
        {
            goalPos = new Vector3(Random.Range(-worldSize, worldSize),
                                  Random.Range(0, waterLevel),
                                  Random.Range(-worldSize, worldSize));
            //Debug.Log("go");
            goalPrefab.transform.position = goalPos;
            if (Random.Range(0, 10000) < 5000)
            {
                ndGoalPos = new Vector3(Random.Range(-worldSize, worldSize),
                                      Random.Range(0, waterLevel),
                                      Random.Range(-worldSize, worldSize));
                ndGoalPrefab.transform.position = ndGoalPos;
            }
        }




        /*
            if (Random.Range(0, 10000) < 30)
            {
            spawnPos = new Vector3(Random.Range(-worldSize, worldSize),
                                      Random.Range(0, waterLevel),
                                      Random.Range(-worldSize, worldSize));
            while (Vector3.Distance(spawnPos, Vector3.zero) <= 150)
			    {
			    spawnPos = new Vector3(Random.Range(-worldSize, worldSize),
									  Random.Range(0, waterLevel),
									  Random.Range(-worldSize, worldSize));
			    
		        }
			spawnPrefab.transform.position = spawnPos;
		    }*/
    }

}