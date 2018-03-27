using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class GameController : MonoBehaviour {

    public int currentLevel;
    public int maxLevel;
    public string scene;

    public Color loadToColor = Color.white;
    public Music music;
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

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }


    void Start () {
        if (currentLevel == 1)
        {
            PlayerPrefs.SetInt("totalScore", 0);
        }

        if(score != null)
            score.score = PlayerPrefs.GetInt("localScore", 100);

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void updateLevel()
    {
        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore", 0) + score.score);
        PlayerPrefs.SetInt("localScore", 100);

        if (currentLevel + 1 < maxLevel)
        {
            /* currentLevel++;
             PlayerPrefs.SetInt("currentLevel", currentLevel);*/

            switch (currentLevel)
            {
                case 1:
                    Initiate.Fade(scene, loadToColor, 0.5f);
                    music.PlayOutro();
                    break;
                case 2:
                    Initiate.Fade(scene, loadToColor, 0.5f);
                    music.PlayOutro();
                    break;
                case 3:
                    Initiate.Fade(scene, loadToColor, 0.5f);
                    music.PlayOutro();
                    break;
                default:
                    break;
            }
            
        }
        else
        {
            Initiate.Fade("GameOver", loadToColor, 0.5f);
            music.PlayOutro();
        }
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void restartGame()
    {
        
        if (currentLevel == maxLevel)
        {
            PlayerPrefs.SetInt("totalScore", 0);
            PlayerPrefs.SetInt("localScore", 100);
            Initiate.Fade("Level1", Color.black, 0.5f);
        }
        else
        {
            PlayerPrefs.SetInt("localScore", score.score);
            Initiate.Fade("Level" + currentLevel, Color.black, 0.5f);
            music.Die();
        }
        
    }
}
