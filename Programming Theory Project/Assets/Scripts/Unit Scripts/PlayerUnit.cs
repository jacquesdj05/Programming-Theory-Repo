using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        MoveAcross();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyUnit"))
        {
            DealDamage(other);
        }

        if (other.CompareTag("Enemy_Zone"))
        {
            Destroy(gameObject);
        }
    }

    protected void ChargeUnitCost()
    {
        Debug.Log("Instantiated a " + gameObject.name + " costing " + cost);
        playerController.credits -= cost;
    }
}
