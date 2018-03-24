using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int currentLevel = 1;
    public int maxLevel;
    public static int currentScore = 0;

    public Score score;
    public totalScore totalScore;


	// Use this for initialization
	void Start () {
        maxLevel = 3;
        totalScore.setTotalScore(currentScore);
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
        currentScore = score.score;
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
