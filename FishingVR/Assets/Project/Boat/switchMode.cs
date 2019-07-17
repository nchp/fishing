using UnityEngine;
using System.Collections;

public class switchMode : MonoBehaviour
{

    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 

        //set to boat mode//
        if (Input.GetKey("1"))
        {
            boat.GetComponent<Rigidbody>().isKinematic = false;//look at boat component > kinematic off
            boat.GetComponent<Boat>().enabled = true;//check the boat script
            boatCamera.SetActive(true);

            player.SetActive(false);
        }

        //set to FPS mode//
        if (Input.GetKey("2"))
        {
            boat.GetComponent<Rigidbody>().isKinematic = true;//look at boat component > kinematic on
            boat.GetComponent<Boat>().enabled = false;//uncheck the boat script
            boatCamera.SetActive(false);

            player.SetActive(true);
            player.transform.position = playerStartPos.transform.position;
        }
    }
}
