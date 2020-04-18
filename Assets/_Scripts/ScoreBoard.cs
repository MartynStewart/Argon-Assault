using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;
    private Text missileText;
    private Text livesText;

    [SerializeField] int hitScore;

    void Awake() {

        //Handle_Score
        scoreText = GameObject.Find("PointsTxt").GetComponent<Text>();
        UpdateScore();

        //Handle_Missiles
        missileText = GameObject.Find("/Canvas/MissileImg/MissileTxt").GetComponent<Text>();

        //Handle_Lives
        livesText = GameObject.Find("/Canvas/LivesOverlay/LivesImg/LivesTxt").GetComponent<Text>();
    }

    private void UpdateScore() {
        scoreText.text = score.ToString("D9");
    }

    public void IncrementScore(int increment) {
        if (increment < 1) return;
        score += increment;
        UpdateScore();
    }

    public void ChangeMissiles(int missCount) {
        if (missCount < 0) missCount = 0;
        string outString = missCount + "x";
        missileText.text = outString;
    }

    public void ChangeLives(int livCount) {
        if (livCount < 0) livCount = 0;
        string outString = livCount + "x";
        livesText.text = outString;
    }
}
