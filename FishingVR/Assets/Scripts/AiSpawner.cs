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
    public bool enableSpawner { get { return m_enableSpawner; } }

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

    [Header("Main Settings")]
    [SerializeField]
    private bool m_enableSpawner;
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
    public string[] animals = new string[]
    {
        "anchovy",
        "catfish",
        "eel",
        "frog"
    };

    public List<Transform> Waypoints = new List<Transform>();

    public float spawnTimer { get { return m_spawnTimer; } }
    public Vector3 spawnArea { get { return m_spawnArea; } }

    [Header("Global Stats")]
    [Range(0f, 600f)]
    [SerializeField]
    private float m_spawnTimer;
    [SerializeField]
    private Color m_spawnColor = new Color(1.000f, 0.000f, 0.000f, 0.300f);
    [SerializeField]
    private Vector3 m_spawnArea = new Vector3(20f, 10f, 20f);

    [Header("Ai Group Settings")]
    public AiObjects[] AiObject = new AiObjects[2];

    // Start is called before the first frame update
    void Start()
    {
        GetWaypoints();
        RandomizeGroups();
        CreateAiGroups();
        InvokeRepeating("SpawnNPC", 0.5f, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNPC()
    {
        for(int i=0; i<AiObject.Length; i++)
        {
            if(AiObject[i].enableSpawner && AiObject[i].objectPrefab != null)
            {
                GameObject tempGroup = GameObject.Find(AiObject[i].AiGroupName);
                if(tempGroup.GetComponentInChildren<Transform>().childCount < AiObject[i].maxAi)
                {
                    for(int y=0; y<AiObject[i].spawnAmount; y++)
                    {
                        Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
                        GameObject tempSpawn;
                        tempSpawn = Instantiate(AiObject[i].objectPrefab, RandomPosition(), randomRotation);
                        tempSpawn.transform.parent = tempGroup.transform;
                        tempSpawn.AddComponent<AiMove>();
                    }
                }
            }
        }
    }

    public Vector3 RandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, 0),
            Random.Range(-spawnArea.z, spawnArea.z)
            );

        randomPosition = transform.TransformPoint(randomPosition * .5f);
        return randomPosition;
    }

    public Vector3 RandomWaypoint()
    {
        int randomWP = Random.Range(0, (Waypoints.Count - 1));
        Vector3 randomWaypoint = Waypoints[randomWP].transform.position;
        return randomWaypoint;
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = m_spawnColor;
        Gizmos.DrawCube(transform.position, spawnArea);
    }
}
