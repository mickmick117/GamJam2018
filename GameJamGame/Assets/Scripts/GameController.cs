using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int currentLevel = 1;
    public int maxLevel;
    public static int currentScore = 0;

    public Score score;
    public totalScore totalScore;

    public GameObject background;
    public GameObject foreground;
    public GameObject sky;

    public Sprite[] bgList;
    public Sprite[] fgList;
    public Sprite[] skyList;
    public Sprite[] platformList;
    public Sprite[] movingTileList;


    // Use this for initialization
    void Start () {
        maxLevel = 2;
        totalScore.setTotalScore(currentScore);

        SpriteRenderer bg = background.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        SpriteRenderer fg = foreground.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        SpriteRenderer sk = sky.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;


        bg.sprite = bgList[currentLevel-1];
        fg.sprite = fgList[currentLevel - 1];
        sk.sprite = skyList[currentLevel - 1];

       GameObject[] allTile;
       allTile = GameObject.FindGameObjectsWithTag("tileTag");
        

        for (int i = 0; i < allTile.Length; i++)
        {
            SpriteRenderer t = allTile[i].GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            t.sprite = platformList[currentLevel - 1];
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void updateLevel()
    {
        if (currentLevel + 1 <= maxLevel)
        {
            currentLevel++;  
        }
        currentScore = currentScore + score.score;
        totalScore.setTotalScore(currentScore);
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void restartGame()
    {
        currentLevel = 1;
        currentScore = 0;
        totalScore.setTotalScore(0);
    }
}
