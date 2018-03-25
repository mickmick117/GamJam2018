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

    public GameObject[] player;
    public Camera cam;

    public Sprite[] bgList;
    public Sprite[] fgList;
    public Sprite[] skyList;
    public Sprite[] platformList;
    public Sprite[] movingTileList;


    // Use this for initialization
    void Start () {
        maxLevel = 2;
        PlayerPrefs.SetInt("maxLevel", 2);
        currentLevel = PlayerPrefs.GetInt("currentLevel",1);

        
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
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void updateLevel()
    {
        if (currentLevel + 1 <= PlayerPrefs.GetInt("maxLevel"))
        {
            currentLevel++;
            PlayerPrefs.SetInt("currentLevel", currentLevel);
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
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        currentScore = 0;
        totalScore.setTotalScore(0);
    }
}
