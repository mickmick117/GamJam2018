using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashText : MonoBehaviour {

    private float alpha = 1.0f;
    bool fadeOut = true;

    private float alphaVariance = 0.02f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (fadeOut)
        {

            if (alpha > 0.0f)
            {
                alpha = alpha - alphaVariance;

            }
            else
            {
                fadeOut = false;
            }
        }
        else
        {
            if (alpha < 1.0f)
            {
                alpha = alpha + alphaVariance;
            }
            else
            {
                fadeOut = true;
            }
        }        

        GetComponent<UnityEngine.UI.Text>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
