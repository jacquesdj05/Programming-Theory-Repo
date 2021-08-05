using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : EnemyUnit
{
    // Start is called before the first frame update
    void Start()
    {
        health = 5f;
        attackPower = 5f;
        speed = -5f;

        //cost = 5;
    }
}
