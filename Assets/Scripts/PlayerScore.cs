using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int currentScore;
    Text scoreString;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = getScore();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = getScore();
    }

    public int getScore()
    {
        return GlobalScore.score;
    }

    public Text scoreToString()
    {
        scoreString.text = getScore().ToString();
        return scoreString;
    }

    public static void increaseScore(int amount)
    {
        GlobalScore.score += amount;
    }
}
