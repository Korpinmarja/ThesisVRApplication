using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCampfire : MonoBehaviour
{
    public GameObject LogHolder;
    public GameObject branch1;
    public GameObject branch2;
    public GameObject firezone;

    public void CampfireReset()
    {
        foreach (Transform child in LogHolder.transform) {
            GameObject.Destroy(child.gameObject);
        }
        branch1.SetActive(true);
        branch2.SetActive(false);
        firezone.SetActive(false);
    }

}
