using UnityEngine;
using System.Collections;

public class testGBF : MonoBehaviour
{

    public GameObject fishPrefab; //get prefab from outside
    public static int tankSize = 10; //can edit tank size from outside
    public static int waterLevel = 10;
    public GameObject goalPrefab;
    public GameObject ndGoalPrefab;
    public GameObject midPointPrefab;
    public static int numFish = 10; //can edit numFish outside
    public static GameObject[] allFish = new GameObject[numFish];
    public static Vector3 goalPos = Vector3.zero;
    public static Vector3 ndGoalPos = Vector3.zero;
    public static Vector3 midPos = Vector3.zero;
    public static float midPosX;
    public static float midPosZ;
    



    // Use this for initialization
    void Start()
    {
        midPos = midPointPrefab.transform.position;
        midPosX = midPointPrefab.transform.position.x;
        midPosZ = midPointPrefab.transform.position.z;

        for (int i = 0; i < numFish; i++)//loop for spawning fish randomly
        {
            Vector3 pos = new Vector3(Random.Range(midPosX - tankSize, midPosX + tankSize),
                                      Random.Range(0, waterLevel),//y = water level
                                      Random.Range(midPosZ - tankSize, midPosZ + tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()//changing the goalpos of the fish
    {
        int worldSize = testSpawn.worldSize;
        midPos = midPointPrefab.transform.position;
        
        if (Random.Range(0, 10000) < 30)
        {
            goalPos = new Vector3(Random.Range(-worldSize, worldSize),
                                  Random.Range(0, waterLevel),
                                  Random.Range(-worldSize, worldSize));
            

            if (Random.Range(0, 10000) < 5000)
            {
                ndGoalPos = new Vector3(Random.Range(-worldSize, worldSize),
                                      Random.Range(0, waterLevel),
                                      Random.Range(-worldSize, worldSize));
                
            }
        }
        
    }
}
