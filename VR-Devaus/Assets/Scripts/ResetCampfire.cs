using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCampfire : MonoBehaviour
{
    public GameObject LogHolder;

    public GameObject branch1;
    public GameObject branch2;
    public GameObject branch3;
    public GameObject branch4;
    public GameObject branch5;

    public GameObject sparkzone;

    public void CampfireReset()
    {
        foreach (Transform child in LogHolder.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }

        branch1.SetActive(true);
        branch2.SetActive(false);
        branch3.SetActive(false);
        branch4.SetActive(false);
        branch5.SetActive(false);
        sparkzone.SetActive(false);
    }
}
