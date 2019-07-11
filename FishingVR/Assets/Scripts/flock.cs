using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour
{

    public float speed = 0.001f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading; //flock condition heading same way for a whole group
    Vector3 averagePosition;//average position of the whole group
    Vector3 yPos;
    float neighbourDistance = 2.0f;
    bool turning = false;

    // Use this for initialization
    void Start()
    {

        speed = Random.Range(0.5f, 1);//random speed of each fish
    }

    // Update is called once per frame


    void Update()
    {
        Vector3 baitPos = dropTheBait.baitPos;
        Vector3 nowPos = transform.position;
        //fix pls
        if (baitPos == nowPos)
        {
            nowPos = baitPos;
        }

        
        else
        { 
            yPos = new Vector3(0f, transform.position.y, 0f);
            if ((Vector3.Distance(transform.position, Vector3.zero) >= globalFlock.tankSize) || (Vector3.Distance(yPos, Vector3.zero) >= globalFlock.waterLevel))//condition for prevent fish getting out of the tank
            {
                turning = true;

            }
            else
                turning = false;

            if (turning)
            {
                Vector3 direction = Vector3.zero - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          rotationSpeed * Time.deltaTime);
                speed = Random.Range(0.5f, 1);
            }
            else
            {
                if (Random.Range(0, 5) < 1)
                    ApplyRules();

            }
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }



    void ApplyRules()//flock function
    {
        GameObject[] gos;
        gos = globalFlock.allFish;//can get all data from fish from globalFlock

        Vector3 vcentre = Vector3.zero;//get in the same way(center of the group)
        Vector3 vavoid = Vector3.zero;//avoid hitting
        float gSpeed = 0.1f;

        Vector3 goalPos = globalFlock.goalPos;
        Vector3 ndGoalPos= globalFlock.ndGoalPos;
        Vector3 baitPos = dropTheBait.baitPos;
        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)//if <= u are in neighbour
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (dist < 1.0f)//too close avoid
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }

        if (groupSize > 0)
        {

            if (Random.Range(0, 10000) < 7500)//get baited
            {
                vcentre = vcentre / groupSize + (baitPos - this.transform.position);
                speed = gSpeed / groupSize;

                Vector3 direction = (vcentre + vavoid) - transform.position;

                if (direction != Vector3.zero)//turning 
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          rotationSpeed * Time.deltaTime);
            }
            if (Random.Range(0, 10000) > 2500)
            {
                vcentre = vcentre / groupSize + (ndGoalPos - this.transform.position);
                speed = gSpeed / groupSize;

                Vector3 direction = (vcentre + vavoid) - transform.position;

                if (direction != Vector3.zero)//turning 
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          rotationSpeed * Time.deltaTime);
            }
            else
            {

                vcentre = vcentre / groupSize + (goalPos - this.transform.position);
                speed = gSpeed / groupSize;

                Vector3 direction = (vcentre + vavoid) - transform.position;


                    if (direction != Vector3.zero)//turning 
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          rotationSpeed * Time.deltaTime);
            }

        }

    }
}