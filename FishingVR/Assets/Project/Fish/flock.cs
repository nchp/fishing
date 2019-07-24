using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour
{

    public float speed = 0.001f;
    float rotationSpeed = 5.0f;
    Vector3 averageHeading; //flock condition heading same way for a whole group
    Vector3 averagePosition;//average position of the whole group
    Vector3 yPos;
    float neighbourDistance = 0.9f;
    bool turning = false;
    public static int  fCatch;

    // Use this for initialization
    void Start()
    {

        speed = Random.Range(0.1f, 0.7f );//random speed of each fish

    }

    // Update is called once per frame


    void Update()
    {
        //Debug.Log(baitCode.baitEnable);
        Vector3 hookPos = dropTheBait.hookPos;
        Vector3 nowPos = this.transform.position;
        float Range = Vector3.Distance(hookPos, nowPos);
        //fix pls
        Vector3 islandPos = Vector3.zero;
        Vector3 midPos = globalFlock.midPos;
        //Debug.Log(baitCode.baitEnable);
        //if (this.transform.position == hookPos)
        //{
        //      this.transform.position = hookPos;
        //}


        if ((Range <= 0.3f) && (fCatch == 0))
        {

            fCatch = 1;
            //Debug.Log(fCatch);

        }

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



    void ApplyRules()//flock function
    {
        
        GameObject[] gos;
        gos = globalFlock.allFish;//can get all data from fish from globalFlock

        Vector3 hookPos = dropTheBait.hookPos;
        Vector3 nowPos = this.transform.position;
        float Range = Vector3.Distance(hookPos, nowPos);

        Vector3 vcentre = globalFlock.midPos;//get in the same way(center of the group)
        Vector3 vavoid = globalFlock.midPos;//avoid hitting
        float gSpeed = 0.05f;

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

                    if (dist < 0.2f)//too close avoid
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                        
                    }

                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }



        if (this.transform.position == baitPos)
        {
            baitCode.baitEnable = 0;
        }
        if (groupSize > 0)
        {
            if (baitCode.baitEnable == 1)
            {
                if (Random.Range(0, 10000) > 1000)//get baited
                {
                    vcentre = vcentre / groupSize + (baitPos - this.transform.position);
                    speed = gSpeed / groupSize;

                    Vector3 direction = (vcentre + vavoid) - transform.position;

                    if (direction != Vector3.zero)//turning 
                        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                              Quaternion.LookRotation(direction),
                                                              rotationSpeed * Time.deltaTime);
                   /* if ((Range <= 0.2f) && (baitCode.baitEnable == 1))
                    {

                        baitCode.baitEnable = 0;
                        this.transform.position = hookPos;
                        fCatch = 1;
                        Debug.Log("Pbait");

                    }*/

                }


                 
            }

            



            else if (Random.Range(0, 10000) > 2500)
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