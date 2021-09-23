using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] protected float grillTime;

    public GameObject scoreTextPrefab;
    public Material rawMaterial;
    public Material cookedMaterial;
    public Material overCookedMaterial;
    public Material selectedMaterial;

    private Renderer render;

    private int currentScore;
    private bool isGrilling;
    private bool isSelected;

    private float timer;
    protected float cookedTime;
    protected float overCookedTime;

    private void Start() {
        render = GetComponent<Renderer>();
        OnMeatStateUpdate(MeatState.RAW);

        CalculateRule();
    }

    private void Update() {
        if (isGrilling) {
            Grilling();
        }
    }

    public void OnSelected() {
        if (isSelected) {
            render.material = rawMaterial;
        }
        else {
            if (isGrilling) {
                isGrilling = false;

                SubmitScore();
                Destroy(gameObject);
            }
            else {
                render.material = selectedMaterial;
            }
        }
        isSelected = !isSelected;
    }

    public void OnGrilling() {
        timer = 0;
        isGrilling = true;
    }

    protected virtual void CalculateRule() {
        //set cookedTime to 80% off grillTime
        cookedTime = grillTime * 0.8f;

        //set overCookedTime to 150% off grillTime
        overCookedTime = grillTime * 1.5f;
    }

    private void Grilling() {
        timer += Time.deltaTime;

        if (timer > overCookedTime) {
            OnMeatStateUpdate(MeatState.OVER_COOKED);
        }
        else if (timer > cookedTime) {
            OnMeatStateUpdate(MeatState.COOKED);
        }
    }

    private void OnMeatStateUpdate(MeatState newState) {
        switch (newState) {
            case MeatState.OVER_COOKED:
                currentScore = -score;
                render.material = overCookedMaterial;
                break;
            case MeatState.COOKED:
                currentScore = score;
                render.material = cookedMaterial;
                break;
            default:
                currentScore = -score;
                render.material = rawMaterial;
                break;
        }
    }

    private void SubmitScore() {
        GameManager.Instance.AddScore(currentScore);

        GameObject instance = Instantiate(scoreTextPrefab, transform.position, scoreTextPrefab.transform.rotation);
        instance.GetComponent<FloatingText>().SetText(currentScore); ;
    }

    private enum MeatState
    {
        RAW,
        COOKED,
        OVER_COOKED,
    }
}
