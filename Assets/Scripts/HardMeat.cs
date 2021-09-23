using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class HardMeat : Meat
{
    // POLYMORPHISM
    protected override void CalculateRule() {
        //set cookedTime to 90% off grillTime
        cookedTime = grillTime * 0.9f;

        //set overCookedTime to 110% off grillTime
        overCookedTime = grillTime * 1.1f;
    }
}
