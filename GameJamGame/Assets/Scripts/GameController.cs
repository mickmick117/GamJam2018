using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class GameController : MonoBehaviour {

    public int currentLevel;
    public int maxLevel;
    //private int currentScore = 0;

    public Score score;
    public totalScore totalScore;

   /* public GameObject background;
    public GameObject foreground;
    public GameObject sky;*/

   /* public GameObject[] players;
    public GameObject playerContainer;
    public Camera cam;

    public Sprite[] bgList;
    public Sprite[] fgList;
    public Sprite[] skyList;
    public Sprite[] platformList;
    public Sprite[] movingTileList;*/


    // Use this for initialization
    void Start () {
        maxLevel = 2;
        totalScore.score = PlayerPrefs.GetInt("totalScore", 0);
       /* PlayerPrefs.SetInt("maxLevel", 2);
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
        }*/
    }

    /*private void addPlayer ()
    {
        players[currentLevel - 1].transform.parent = playerContainer;
    }*/

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
            /* currentLevel++;
             PlayerPrefs.SetInt("currentLevel", currentLevel);*/

         /*   switch (currentLevel)
            {
                case 1:
                    SceneManager.LoadScene("level1");
                    break;
                case 2:
                    SceneManager.LoadScene("level 2");
                    break;
                case 3:
                    SceneManager.LoadScene("level3");
                    break;
                default:
                    break;
            }*/
        }
        //currentScore = currentScore + score.score;
        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore", 0) + score.score);
        //totalScore.setTotalScore(currentScore);
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void restartGame()
    {
        //currentScore = 0;
        //totalScore.setTotalScore(0);
        PlayerPrefs.SetInt("totalScore", 0);
        SceneManager.LoadScene("level1");
    }
}
