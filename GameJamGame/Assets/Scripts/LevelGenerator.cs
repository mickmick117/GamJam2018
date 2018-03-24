using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

   public GameObject Ground;

    int nbOfGround;
    int maxLength;
    int minLength;
    int maxHeigth;
    int currentLevel = 1;


	// Use this for initialization
	void Start () {
        nbOfGround = 100;
        maxLength = 8;
        minLength = 1;
        maxHeigth = 3;

        Instantiate(Ground, new Vector2(0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
