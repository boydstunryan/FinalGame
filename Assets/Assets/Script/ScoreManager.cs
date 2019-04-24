using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();

        score = 0;
    }

    void Update()
    {
        if (score < 0)
            score = 0;

        scoreText.text = " " + score;
    }

    public static void AddPoints (int pointsToAdd)
    {
        score += pointsToAdd;
    }
}
