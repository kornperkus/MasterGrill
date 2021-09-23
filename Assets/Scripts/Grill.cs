using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    [SerializeField] private GameObject[] meatObjects = new GameObject[4];
    [SerializeField] private Transform[] gridPosition = new Transform[4];

    public void AddNewMeat(GameObject meat) {
        for (int i = 0; i < meatObjects.Length; i++) {
            if (meatObjects[i] == null) {
                meatObjects[i] = meat;
                meatObjects[i].transform.position = gridPosition[i].position;
                break;
            }
        }
    }
}
