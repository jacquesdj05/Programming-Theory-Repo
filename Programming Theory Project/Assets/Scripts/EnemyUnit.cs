using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    private void Start()
    {
        speed *= -1;
    }

    private void Update()
    {
        MoveAcross();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerUnit"))
        {
            DealDamage(other);
        }

        if (other.CompareTag("Player_Zone"))
        {
            Destroy(gameObject);
        }
    }
}
