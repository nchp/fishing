using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AiObjects
{
    public string AiGroupName { get { return m_aiGroupName; } }
    public GameObject objectPrefab { get { return m_prefab; } }
    public int maxAi { get { return m_maxAi; } }
    public int spawnRate { get { return m_spawnRate; } }
    public int spawnAmount { get { return m_maxSpawnAmount; } }
    public bool randomizeStats { get { return m_randomizeStats; } }

    [Header("Ai Group Stats")]
    [SerializeField]
    private string m_aiGroupName;
    [SerializeField]
    private GameObject m_prefab;
    [SerializeField]
    [Range(0f, 30f)]
    private int m_maxAi;
    [SerializeField]
    [Range(0f, 20f)]
    private int m_spawnRate;
    [SerializeField]
    [Range(0f, 10f)]
    private int m_maxSpawnAmount;
    [SerializeField]
    private bool m_randomizeStats;

    public AiObjects(string Name, GameObject Prefab, int MaxAi, int SpawnRate, int MaxSpawnAmount, bool RandomizeStats)
    {
        this.m_aiGroupName = Name;
        this.m_prefab = Prefab;
        this.m_maxAi = MaxAi;
        this.m_spawnRate = SpawnRate;
        this.m_maxSpawnAmount = MaxSpawnAmount;
        this.m_randomizeStats = RandomizeStats;
    }

    public void setValues(int MaxAi, int SpawnRate, int MaxSpawnAmount)
    {
        this.m_maxAi = MaxAi;
        this.m_spawnRate = SpawnRate;
        this.m_maxSpawnAmount = MaxSpawnAmount;
    }
}

public class AiSpawner : MonoBehaviour
{

    public List<Transform> Waypoints = new List<Transform>();

    [Header("Ai Group Settings")]
    public AiObjects[] AiObject = new AiObjects[5];

    // Start is called before the first frame update
    void Start()
    {
        GetWaypoints();
        RandomizeGroups();
        CreateAiGroups();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomizeGroups()
    {
        for(int i = 0; i < AiObject.Length; i++)
        {
            if(AiObject[i].randomizeStats)
            {
                // AiObject[i] = new AiObjects(AiObject[i].AiGroupName, AiObject[i].objectPrefab, Random.Range(1, 30), Random.Range(1, 20), Random.Range(1, 10), AiObject[i].randomizeStats);
                AiObject[i].setValues(Random.Range(1, 30), Random.Range(1, 20), Random.Range(1, 10));

            }
        }
    }

    void CreateAiGroups()
    {
        GameObject AiGroupSpawn;

        for(int i = 0; i < AiObject.Length; i++)
        {
            AiGroupSpawn = new GameObject(AiObject[i].AiGroupName);
            AiGroupSpawn.transform.parent = this.gameObject.transform;
        }
    }

    void GetWaypoints()
    {
        Transform[] waypointList = transform.GetComponentsInChildren<Transform>();
        for(int i = 0; i < waypointList.Length; i++)
        {
            if(waypointList[i].tag == "waypoint")
            {
                Waypoints.Add(waypointList[i]);
            }
        }
    }
}
