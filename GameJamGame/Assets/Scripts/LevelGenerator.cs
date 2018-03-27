using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference: https://www.youtube.com/watch?v=DmYArT8h4EQ

public class LevelGenerator : MonoBehaviour {

   public GameObject Ground;
   public GameObject MovingTile;
   public GameObject FinishLine;
   public GameController game;

    public int maxGround;
    public int maxLength;
    public int minLength;
    public int maxHeigth;
    public int minHeigth;
    public int maxEmptySpace;
    int currentEmptySpace;
    int tileIteration;

    public float emptyProbability;
    public float movingTileProbability;

	// Use this for initialization
	void Start () {

        setDifficulty();
        tileIteration = 1;
        currentEmptySpace = 0;

        Instantiate(Ground, new Vector2(0, 0), Quaternion.identity);

        for (int i = 1; i < maxGround; i++)
        {
            int emptyRandom = Random.Range(0, 100);
            int movingTileRandom = Random.Range(0, 100);
            int heigth;

            if (movingTileRandom < movingTileProbability) // on met une grande tuile qui bouge
            {
                heigth = Mathf.RoundToInt(Random.Range(minHeigth, maxHeigth));

                tileIteration += 4;
                Instantiate(MovingTile, new Vector2(tileIteration, heigth), Quaternion.identity);
                tileIteration += 3;
                tileIteration += 4;
            }
            else if (emptyRandom < emptyProbability && currentEmptySpace < maxEmptySpace) // on met du vide
            {
                currentEmptySpace++;
                tileIteration++;
            }
            else // on met des tuiles normales
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

        for (int i = 0; i < 40; i++) // ajout dune ligne droite
        {
            Instantiate(Ground, new Vector2(tileIteration, 0), Quaternion.identity);
            tileIteration++;
        }

        Instantiate(FinishLine, new Vector2(tileIteration, 1), Quaternion.identity);

        for (int i = 0; i < 50; i++) // ajout dune ligne droite
        {
            Instantiate(Ground, new Vector2(tileIteration, 0), Quaternion.identity);
            tileIteration++;
        }
    }

    private void setDifficulty()
    {
        /*int prob = 10 * game.getLevel() > 90 ? 90 : 10 * game.getLevel();
        emptyProbability = prob;
        movingTileProbability = prob;*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
