using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference: https://answers.unity.com/questions/769707/how-to-make-moving-tiles-in-side-scroller.html

public class MovingTile : MonoBehaviour {

    private bool movingLeft;
    private bool movingDown;
    private Vector3 initialPosition;
    private int movingLength = 3;
    private bool horizontal = true;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        float directionRandom = Random.Range(0, 100);

        if (directionRandom > 50) // horizontal
        {
            float randomDeplacement = Random.Range(movingLength * -1, movingLength);
            transform.Translate(new Vector2(randomDeplacement, 0));
            horizontal = true;
        }
        else // vertical
        {
            float randomDeplacement = Random.Range(movingLength * -1, movingLength);
            transform.Translate(new Vector2(0, randomDeplacement));
            horizontal = false;
        }
        InvokeRepeating("MoveTile", 0.0f, 0.02f);
    }

    // Update is called once per frame
    void Update () {

       
    }

    private void MoveTile()
    {
        if (horizontal)
        {       
            if (transform.position.x < initialPosition.x - movingLength)
            {
                movingLeft = false;
            }
            if (transform.position.x > initialPosition.x + movingLength)
            {
                movingLeft = true;
            }
            if (movingLeft)
            {
                transform.Translate(new Vector2(-0.05f, 0));
            }
            else
            {
                transform.Translate(new Vector2(0.05f, 0));
            }
        }
        else
        {
            if (transform.position.y < initialPosition.y - movingLength)
            {
                movingDown = false;
            }
            if (transform.position.y > initialPosition.y + movingLength)
            {
                movingDown = true;
            }
            if (movingDown)
            {
                transform.Translate(new Vector2(0, -0.05f));
            }
            else
            {
                transform.Translate(new Vector2(0, 0.05f));
            }
        }
    }
}
