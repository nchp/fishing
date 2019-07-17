using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePoint : MonoBehaviour
{
    public static Vector3 endPos = Vector3.zero;
    public static Vector3 startPos = Vector3.zero;
    public static Vector3 endFixPos = Vector3.zero;
    public static Vector3 startFixPos = Vector3.zero;
    public GameObject endPointPrefab; //get prefab from outside
    public GameObject startPointPrefab;
    public GameObject endFixPointPrefab;
    public GameObject startFixPointPrefab;
    public GameObject fixPloePrefab;
    public GameObject movePolePrefab;
    public GameObject mesh;
    public static int Length = 17;
    public static Vector3 wDistance = Vector3.zero;
    Vector3 wPos = Vector3.zero;
    public GameObject pointPrefab;

    // Start is called before the first frame update
    void Start()
    {

        //Vector3 pos = transform.position;
        //float posLength = (transform.position.z) + 10;//z
        //Debug.Log(pos);

    }

    // Update is called once per frame
    void Update()
    {        endPos = endPointPrefab.transform.position;
        startPos = endPointPrefab.transform.position;
        endFixPos = endFixPointPrefab.transform.position;
        startFixPos = startFixPointPrefab.transform.position;        wDistance =  endPos - endFixPos;
        Vector3 pos = mesh.transform.position;

        /******************************************************************************************/

        float posLength = (transform.position.z) + 10;//z

        float wRatio;

        wRatio = Mathf.Pow(posLength, 2) * ((3 * Length) - posLength) / (2 * Mathf.Pow(Length, 3));        /******************************************************************************************/

        Debug.Log(wRatio);

        wPos = pos + (new Vector3 (wDistance.x,wDistance.y,0) * wRatio) ;

        transform.position = wPos;





    }
}
