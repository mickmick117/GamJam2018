using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int currentLevel = 1;
    public int maxLevel;


	// Use this for initialization
	void Start () {
        maxLevel = 3;
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
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void restartGame()
    {
        currentLevel = 1;
    }
}
