using UnityEngine;
using System.Collections;

public class testFlock : MonoBehaviour
{

    public float speed = 0.001f;
    float rotationSpeed = 10.0f;
    Vector3 averageHeading; //flock condition heading same way for a whole group
    Vector3 averagePosition;//average position of the whole group
    Vector3 yPos;
    float neighbourDistance = 5.0f;
    bool turning = false;

    // Use this for initialization
    void Start()
    {

        //speed = Random.Range(0.5f, 5);//random speed of each fish
        speed = 0.5f;
    }

    // Update is called once per frame


    void Update()
    {
        Vector3 hookPos = dropTheBait.hookPos;
        Vector3 nowPos = transform.position;
        float Range = Vector3.Distance(hookPos, nowPos);
        //fix pls
        Vector3 islandPos = Vector3.zero;
        Vector3 midPos = testGBF.midPos;
        //Debug.Log(baitCode.baitEnable);
        if (Range <= 0.5f)
        {
            transform.position = hookPos;

            baitCode.baitEnable = 0;
        }


        else
        {
            yPos = new Vector3(0f, transform.position.y, 0f);

            //  if ((Vector3.Distance(transform.position, Vector3.zero) >= globalFlock.tankSize) || (Vector3.Distance(yPos, Vector3.zero) >= globalFlock.waterLevel))//condition for prevent fish getting out of the tank

            if ((Vector3.Distance(this.transform.position, midPos) >= testSpawn.worldSize)) //|| (Vector3.Distance(yPos, midPos) >= globalFlock.waterLevel))//condition for prevent fish getting out of the tank
            {
                turning = true;

            }


            else

            { turning = false; }


            if (turning)
            {

                Vector3 direction = midPos - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          rotationSpeed * Time.deltaTime);
                //speed = Random.Range(0.5f, 5);

            }
            else
            {
                if (Random.Range(0, 5) < 4)
                {
                    ApplyRules();
                }


            }
            transform.Translate(0, 0, Time.deltaTime * speed);


        }
    }



    void ApplyRules()//flock function
    {

        GameObject[] gos;
        gos = testGBF.allFish;//can get all data from fish from globalFlock

        Vector3 vcentre = testGBF.midPos;//get in the same way(center of the group)
        Vector3 vavoid = testGBF.midPos;//avoid hitting
        float gSpeed = 0.5f;

        Vector3 goalPos = testGBF.goalPos;
        Vector3 ndGoalPos = testGBF.ndGoalPos;
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




        if (this.transform.position == baitPos)
        {
            baitCode.baitEnable = 0;
        }

        if (groupSize > 0)
        {
            if (baitCode.baitEnable == 1)
            {
                if (Random.Range(0, 10000) < 10000)//get baited
                {
                    vcentre = vcentre / groupSize + (baitPos - this.transform.position);
                    speed = gSpeed / groupSize;

                    Vector3 direction = (vcentre + vavoid) - transform.position;

                    if (direction != Vector3.zero)//turning 
                        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                              Quaternion.LookRotation(direction),
                                                              rotationSpeed * Time.deltaTime);
                    Debug.Log("Pbait");
                }
            }

            if (Random.Range(0, 10000) > 2000)

            {
                vcentre = vcentre / groupSize + (ndGoalPos - this.transform.position);
                speed = gSpeed / groupSize;

                Vector3 direction = (vcentre + vavoid) - transform.position;

                if (direction != Vector3.zero)//turning 
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          rotationSpeed * Time.deltaTime);
                Debug.Log("P2");
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
                    Debug.Log("P1");
                }
                
            
        }



    }
}