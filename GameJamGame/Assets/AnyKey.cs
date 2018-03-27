using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKey : MonoBehaviour {


    public Music music;

    // Use this for initialization
    void Start () {
        music.PlayIntro();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
        {
            Initiate.Fade("Level1", Color.black, 0.5f);
            music.Stop();
            music.PlayOutro();
        }
	}
}
