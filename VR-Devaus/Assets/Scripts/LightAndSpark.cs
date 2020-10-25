using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAndSpark : MonoBehaviour
{
    //Numeric variable to detect how many times player have tried to start a fire
    public int Tries;

    //The game object that will cause spark and firestarting
    public GameObject Rock;

    //Gameobject that will go active, if the MaybyFire meets requires
    public GameObject Fire;

    //Random number generetar
    public int MaybyFire;

    //Numeric variable to store MaybyFire and Tries
    public int i;
    
    //Checker to see if the player is in the SparkZone
    public bool AreWeOnRange;

    // Gameobject that check if we are inside the range to try cause spark
    public GameObject Sparkzone;

    // Gameobject that causes the sparkle particle effect
    public Transform sparkPrefab;

    // Timer that tells how long fire burns
    // private IEnumerator coroutine;
    // public float firetime;

    //public GameObject Reset;
    public GameObject Reset;

    void Start()
    {
        //Starting fire starting tries on zero
        Tries = 0;
        //firetime =10;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Makes Rock the other gameobject that collided
        Rock = other.gameObject;

        //Checks if the player is inside FireZone
        AreWeOnRange = Sparkzone.GetComponent<LightUp_Checker>().insideFireZone;

        if (AreWeOnRange != null)
        {
            if (Rock.GetComponent<FireTockTag>() != null && AreWeOnRange==true)
            {

                //ContactPoint contact = other.contacts[0];
                //Quaternion rot = Quaternion.Vector3.up;
                //Vector3 pos = contact.point;
                
                Instantiate(sparkPrefab, transform.position, Quaternion.identity);
                //Destroy(gameObject);
                
                //MaybyFire takes random number
                MaybyFire = Random.Range(0, 10);

                //Putting MaybyFire number and how many times player have tried to start fire to i variable
                i = MaybyFire + Tries;
                
                //if the number is bigger than 9, the fire starts
                if (i > 10)
                {
                    Fire.SetActive(true);
                    //coroutine = BurningFire(firetime);
                    //StartCoroutine(coroutine);
                }

                //Adds one to Tries
                Tries++;
            }
        }
    }
    /*
    private IEnumerator BurningFire(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Fire.SetActive(false);
            AreWeOnRange = false;
            Reset.GetComponent<ResetCampfire>().CampfireReset();
            Tries = 0;
            
        }
    } */
}
