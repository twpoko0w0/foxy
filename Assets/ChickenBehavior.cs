﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{
    public float duration;    //the max time of a walking session (set to ten)
    float elapsedTime = 0f; //time since started walk
    float wait = 0f; //wait this much time
    float waitTime = 0f; //waited this much time

    float randomX;  //randomly go this X direction
    float randomZ;  //randomly go this Z direction

    bool move = true; //start moving

    void Start()
    {
        randomX = Random.Range(-3, 3);
        randomZ = Random.Range(-3, 3);
    }

    void Update()
    {



        //Debug.Log (elapsedTime);

        if (elapsedTime < duration && move)
        {
            //if its moving and didn't move too much
            transform.Translate(new Vector3(randomX, 0, randomZ) * Time.deltaTime);
            elapsedTime += Time.deltaTime;

        }
        else
        {
            //do not move and start waiting for random time
            move = false;
            wait = Random.Range(5, 10);
            waitTime = 0f;
        }

        if (waitTime < wait && !move)
        {
            //you are waiting
            waitTime += Time.deltaTime;


        }
        else if (!move)
        {
            move = true;
            elapsedTime = 0f;
            randomX = Random.Range(-3, 3);
            randomZ = Random.Range(-3, 3);
        }
    }

}
