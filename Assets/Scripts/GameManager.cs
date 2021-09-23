using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }
    [SerializeField] private int totalScore;

    private UIMain mainUI;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    void Start() {
        mainUI = GetComponent<UIMain>();
    }


    public void AddScore(int score) {
        totalScore += score;
        mainUI.UpdateScore(totalScore);
    }

    public void GameEnd() {
        GetComponent<SelectionControl>().enabled = false;

        GameObject[] allMeat = GameObject.FindGameObjectsWithTag("Meat");
        foreach (GameObject meat in allMeat) {
            meat.GetComponent<Meat>().enabled = false;
        }
    }
}
