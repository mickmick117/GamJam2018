using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalScore : MonoBehaviour {

    public int score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = "Total Score : " + score;
    }

    public int getTotalScore ()
    {
        return score;
    }

    public void setTotalScore(int score_)
    {
        score = score_;
    }
}
