using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioEvent : MonoBehaviour
{

    public string name;
    //AudioManager AudioManager;
    AudioSource AudioSource;
    bool hasPlayed;

    private void Start()
    {
        //AudioManager = AudioManager.instance;
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasPlayed)
        {
            Debug.Log("collision detected");
            AudioSource.Play();
            hasPlayed = true;
        }
    }
}
