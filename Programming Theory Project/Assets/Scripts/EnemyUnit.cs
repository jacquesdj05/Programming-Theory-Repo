using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    private void Update()
    {
        MoveAcross();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Enemy Collided with " + other.gameObject.name);

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
