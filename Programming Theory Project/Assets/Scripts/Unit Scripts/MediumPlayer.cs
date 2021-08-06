using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPlayer : PlayerUnit
{
    void Start()
    {
        health = 5f;
        attackPower = 1f;
        speed = 5f;

        cost = 15;

        ChargeUnitCost();
    }
}
