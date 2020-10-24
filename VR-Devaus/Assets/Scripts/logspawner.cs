﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
// This code spawns the logs in logpile
*/

public class logspawner : MonoBehaviour
{
    //Logs that will spawn
    public GameObject spawnedLog;

    //Players controller 
    public GameObject SpawnerHand;

    //Because vectors needs to be whole/primary numbers, this will help to make "halfs" etc. with multiplying or division
    private Vector3 VectorSlicer;

    //Detects when players controller collides with logpspile
    private void OnTriggerEnter(Collider other)
    {
        //Makes SpawnerHand the other gameobject that collided
        SpawnerHand = other.gameObject;

        //
        if(SpawnerHand.name == "LeftController" )
        {
            Instantiate(spawnedLog, transform.position + (VectorSlicer/2), Quaternion.identity);
        }
    }

    void Start()
    {
        //Starting point to the vector //Logs could spawn a little closer to the pile
        VectorSlicer = new Vector3(0, 2, 0);
    }
}
