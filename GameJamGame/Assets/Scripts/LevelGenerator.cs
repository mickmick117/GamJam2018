using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference: https://www.youtube.com/watch?v=DmYArT8h4EQ

public class LevelGenerator : MonoBehaviour {

   public GameObject Ground;
   public GameObject MovingTile;

    int maxGround;
    int maxLength;
    int minLength;
    int maxHeigth;
    int minHeigth;
    int maxEmptySpace;
    int currentEmptySpace;
    int currentLevel = 1;
    int tileIteration;

    float emptyProbability;
    float movingTileProbability;

	// Use this for initialization
	void Start () {
        maxGround = 100;
        maxLength = 8;
        minLength = 1;
        maxHeigth = 3;
        minHeigth = -3;
        maxEmptySpace = 5;
        tileIteration = 1;
        currentEmptySpace = 0;

        emptyProbability = 10;
        movingTileProbability = 10;

        Instantiate(Ground, new Vector2(0, 0), Quaternion.identity);

        for (int i = 1; i < maxGround; i++)
        {
            int emptyRandom = Random.Range(0, 100);
            int movingTileRandom = Random.Range(0, 100);
            int heigth;

            if (movingTileRandom < movingTileProbability)
            {
                heigth = Mathf.RoundToInt(Random.Range(minHeigth, maxHeigth));

                tileIteration += 5;
                Instantiate(MovingTile, new Vector2(tileIteration, heigth), Quaternion.identity);
                tileIteration += 3;
                tileIteration += 5;
            }
            else if (emptyRandom < emptyProbability && currentEmptySpace < maxEmptySpace) // on met du vide
            {
                currentEmptySpace++;
                tileIteration++;
            }
            else
            {
                currentEmptySpace = 0;
                int nbGround = Mathf.RoundToInt(Random.Range(minLength, maxLength));
                heigth = Mathf.RoundToInt(Random.Range(minHeigth, maxHeigth));

                for (int j = 0; j < nbGround; j++)
                {
                    Instantiate(Ground, new Vector2(tileIteration, heigth), Quaternion.identity);
                    tileIteration++;
                }
            }            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
