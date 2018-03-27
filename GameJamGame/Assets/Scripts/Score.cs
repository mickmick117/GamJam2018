using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score = 100;

    // Use this for initialization
    void Start () {
        InvokeRepeating("DecreaseScore", 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = "Score : " + score;
    }

    void DecreaseScore ()
    {
        if (score >= 1)
        {
            score--;
        }
    }
}
