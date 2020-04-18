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

    void Start() {

        //Handle_Score
        scoreText = GameObject.Find("PointsTxt").GetComponent<Text>();
        UpdateScore();

        //Handle_Missiles
        missileText = GameObject.Find("/Canvas/MissileImg/MissileTxt").GetComponent<Text>();
        Debug.Log(missileText.text);

        //Handle_Lives

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

    public void ChangeMissiles(int missCount) {
        if (missCount < 0) missCount = 0;
        string outString = missCount + "x";

        Debug.Log("Debugging String: " + outString);
        missileText.text = outString;
    }

    public void ChangeLives(int count) {
        if (count < 0) count = 0;
        livesText.text = count.ToString();
    }
}
