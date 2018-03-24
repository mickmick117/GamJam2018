using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

   public GameObject Ground;

    int maxGround;
    int maxLength;
    int minLength;
    int maxHeigth;
    int minHeigth;
    int currentLevel = 1;
    int groundIteration;


	// Use this for initialization
	void Start () {
        maxGround = 100;
        maxLength = 8;
        minLength = 1;
        maxHeigth = 3;
        minHeigth = -3;
        groundIteration = 1;

        Instantiate(Ground, new Vector2(0, 0), Quaternion.identity);

        for (int i = 1; i < maxGround; i++)
        {
            int nbGround = Mathf.RoundToInt(Random.Range(minLength, maxLength));
            int heigth = Mathf.RoundToInt(Random.Range(minHeigth, maxHeigth));

            for (int j = 0; j < nbGround; j++)
            {
                Instantiate(Ground, new Vector2(groundIteration, heigth), Quaternion.identity);
                groundIteration++;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
