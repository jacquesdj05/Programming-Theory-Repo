using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : EnemyUnit
{
    // Start is called before the first frame update
    void Start()
    {
        health = 7.5f;
        attackPower = 1f;
        speed = -2.5f;

        //cost = 5;
    }
}
