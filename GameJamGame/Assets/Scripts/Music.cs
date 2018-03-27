using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public AudioClip music;
    public AudioClip intro;
    public AudioClip outro;
    public AudioClip die;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start () {
        MusicSource.clip = music;
        MusicSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayIntro ()
    {
        MusicSource.clip = intro;
        MusicSource.Play();
    }

    public void PlayOutro()
    {
        MusicSource.clip = outro;
        MusicSource.Play();
    }

    public void Die()
    {
        MusicSource.clip = die;
        MusicSource.Play();
    }

    public void Stop ()
    {
        MusicSource.Stop();
    }
}
