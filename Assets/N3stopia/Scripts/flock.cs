using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flock : MonoBehaviour
{
    public float speed = 0.001f;
    float rotationSpeed = 4.0f;

    Vector3 averageHeading;
    Vector3 averagePosition;

    float neighbourDistance = 3.0f;

    bool turning = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) >= globalFlock.tankSize)
        {
            turning = true;
           
;        }
        else 
         turning = false;

         if (turning)
         {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed *Time.deltaTime);
             speed = Random.Range(0.5f,1.0f);
         }
         else
         {
                  if (Random.Range(0,5) < 1)
            ApplyRules();
         }
  
        transform.Translate(Time.deltaTime * speed,0, 0);
    }
    void ApplyRules()
    {
        GameObject[] gos;
        gos = globalFlock.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;

        float gSpeed = 0.1f;

        Vector3 goalPos = globalFlock.goalPos;

        float dist;

        int groupSize = 0;
        foreach( GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance (go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize ++;
                    if (dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }
                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed +anotherFlock.speed;
                }
            }
        }
        if (groupSize > 0)
        {
            vcentre = vcentre/groupSize + ( goalPos- this.transform.position);
            speed = gSpeed/groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
    }
}
