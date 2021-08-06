using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : EnemyUnit
{
    // Start is called before the first frame update
    void Start()
    {
        health = 2.5f;
        attackPower = 1f;
        speed = -7.5f;

        //cost = 5;
    }
}
