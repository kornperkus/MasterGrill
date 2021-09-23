using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameEndPanel;

    private float timer = 15;

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
            gameEndPanel.SetActive(true);
        }
    }

    public void OnReplayClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackClicked() {
        SceneManager.LoadScene(0);
    }
}
