using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class changeScore : MonoBehaviour
{
    public Text myScore;
    public static int nowScore;
    public static int gameStart;
    public static int gameReset;
    public static int haveRod;
    public GameObject rodPrefab;
    public GameObject rodPrePosition;
    public static Vector3 rodOriPosition;
    // Update is called once per frame


    void Update()
    {
        /*Debug.Log("reset");
        Debug.Log(gameReset);
        Debug.Log("start");
        Debug.Log(gameStart);*/
        nowScore = 0;
        rodOriPosition = rodPrePosition.transform.position;
        if (gameStart == 1)
        {
            

            //rodPrefab.SetActive(true);
            if (gameReset == 1)
            {
                Debug.Log("reset ja");
                fishBurn.numRight = 0;
                gameReset = 0;
                rodPrefab.GetComponent<MeshCollider>().enabled = true;

                //if (haveRod == 1 )
                //haveRod = 0;
            }
            else
            {
                nowScore = fishBurn.numRight * 100;
            }



            string newString = nowScore.ToString();
            myScore.text = newString;
        }
        else if (gameStart == 0)
        {
            //rodPrefab.SetActive(false);
            rodPrefab.transform.position = rodOriPosition;
            rodPrefab.GetComponent<MeshCollider>().enabled = false;
            //rodPrefab.SetActive(false);
        }

    }
}
