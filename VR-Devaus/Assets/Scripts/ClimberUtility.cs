using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClimberUtility
{

    /* 
    this is just a code from tutorial and tried to use it, it's not working
    player gameobject has some other gravitymodifiers so player won't go up at all
    here is links for used video tutorials 
    Part 1 https://youtu.be/XGdWIeyKmZE?list=PLmU65k4oXBWWIPpFNTmsxPESQ71BFMoAY
    Part 2 https://youtu.be/qmlMUoN_t2I?list=PLmU65k4oXBWWIPpFNTmsxPESQ71BFMoAY
    */

    public static GameObject GetNearest(Vector3 origin, List<GameObject> collection)
    {
        GameObject nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (GameObject entity in collection)
        {
            distance = (entity.gameObject.transform.position - origin).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = entity;
            }
        }

        return nearest;
    }
}
