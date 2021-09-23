using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionControl : MonoBehaviour
{
    [SerializeField] public Grill grill;
    private Meat selectedMeat;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            OnMouseClicked();
        }
    }

    // ABSTRACTION
    private void OnMouseClicked() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "Grill") {
                if (selectedMeat != null) {
                    grill.AddNewMeat(selectedMeat.gameObject);
                    selectedMeat.OnGrilling();
                    ResetMeat();
                }
            }
            else {
                ResetMeat();
                if (hit.transform.tag == "Meat") {
                    Meat meat = hit.transform.GetComponent<Meat>();
                    if (meat != null) {
                        selectedMeat = meat;
                        selectedMeat.OnSelected();
                    }
                }
            }
        }
    }

    private void ResetMeat() {
        if (selectedMeat != null) {
            selectedMeat.OnSelected();
            selectedMeat = null;
        }
    }
}
