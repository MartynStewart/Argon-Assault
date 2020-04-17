using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;

    [SerializeField] int hitScore;

    void Start() {
        scoreText = GameObject.Find("PointsTxt").GetComponent<Text>();
        score += 2000;
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = score.ToString("D9");
    }

    public void IncrementScore(int increment) {
        if (increment < 1) return;

        score += increment;
        Debug.Log("Updateding score with: " + increment + " Score is now: " + score);
        UpdateScore();
    }
}
