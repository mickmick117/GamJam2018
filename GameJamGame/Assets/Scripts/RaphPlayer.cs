using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaphPlayer : MonoBehaviour {

    public GameController game;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "finishTag")
        {
            game.updateLevel();
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}
