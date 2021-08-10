using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    /// <summary>
    /// Base class from which the player and enemy units derive their characteristics
    /// </summary>

    protected float health;
    protected float attackPower;
    protected float speed;

    [SerializeField]
    protected Unit opponentUnit;

    public virtual void MoveAcross()
    {
        if (opponentUnit == null)   // checks if the unit is currently colliding with an opponent
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public virtual void DealDamage(Collider other)
    {
        // deal damage to opponent's unit or base

        opponentUnit = other.gameObject.GetComponent<Unit>();
        
        health -= opponentUnit.attackPower * Time.deltaTime;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
