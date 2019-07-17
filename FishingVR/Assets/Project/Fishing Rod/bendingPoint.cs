using UnityEngine;
using System.Collections;

public class bendingPoint : MonoBehaviour
{

    public GameObject endPointPrefab; //get prefab from outside
    public GameObject startPointPrefab;
    public GameObject endFixPointPrefab;
    public GameObject startFixPointPrefab;
    public GameObject fixPloePrefab;
    public GameObject movePolePrefab;
    public static int Length = 17; 
    public GameObject pointPrefab;
    public static GameObject[] allPoints = new GameObject[Length];
    public static Vector3 endPos = Vector3.zero;
    public static Vector3 startPos = Vector3.zero;
    public static Vector3 endFixPos = Vector3.zero;
    public static Vector3 startFixPos = Vector3.zero;
    public static Vector3 fixDistance = Vector3.zero;
    public static Vector3 midFix = Vector3.zero;
    public static Vector3 mid = Vector3.zero;
    public static Vector3 Distance = Vector3.zero;
    public static Vector3 wDistance = Vector3.zero;
    public static Vector3 temp = Vector3.zero;
    public static GameObject[] poleMeshPos = new GameObject[Length];
    public static float wRatio;

    // Use this for initialization
    void Start()
    {
        endPos = endPointPrefab.transform.position;
        startPos = endPointPrefab.transform.position;
        endFixPos = endFixPointPrefab.transform.position;
        startFixPos = startFixPointPrefab.transform.position;

        midFix = fixPloePrefab.transform.position;
        mid = movePolePrefab.transform.position;

        endPos = endPointPrefab.transform.position;
        endFixPos = endFixPointPrefab.transform.position;
        //midFix = fixPloePrefab.transform.position;
        //mid = movePolePrefab.transform.position;
        wDistance = endFixPos - endPos;
       
        float L = Length;
        Debug.Log(wDistance);

    }

    // Update is called once per frame
    void Update()//changing the goalpos of the fish
    {

        //move points

        endPos = endPointPrefab.transform.position;
        endFixPos = endFixPointPrefab.transform.position;
        wDistance = endFixPos - endPos;
        float L = Length;

        //Debug.Log(mid);
        //Debug.Log(midFix);
    }
}
