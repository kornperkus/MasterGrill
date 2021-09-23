using System;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 5;

    public void UpdateScore(int score) {
        scoreText.text = "Score: " + score;
    }

    private void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;

            TimeSpan t = TimeSpan.FromSeconds(timer);
            timerText.text = string.Format("{0:d1}:{1:d2}", t.Minutes, t.Seconds);
        }
        else {
            GameManager.Instance.GameEnd();
        }
    }
}
