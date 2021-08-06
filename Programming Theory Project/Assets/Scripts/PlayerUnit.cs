using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    private void Update()
    {
        MoveAcross();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Player unit Collided with " + other.gameObject.name);

        if (other.CompareTag("EnemyUnit"))
        {
            DealDamage(other);
        }

        if (other.CompareTag("Enemy_Zone"))
        {
            Destroy(gameObject);
        }
    }
}
