using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandom : MonoBehaviour
{
    // audiosource to detect what sounds are needed to play
    public AudioSource crowSounds;

    // This random sound is using coroutine and while loop to keep sounds playing 
    void Start ()
    {
        StartCoroutine(RandomWait());
    }
    
    IEnumerator RandomWait()
    {
        // while loop to keep sounds playing and random range working
        while (true) 
        {
            crowSounds.Play();
            yield return new WaitForSeconds(Random.Range(15, 60));
        }
    }
}