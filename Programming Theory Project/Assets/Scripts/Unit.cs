using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    /// <summary>
    /// Base class from which the player and enemy units derive their characteristics
    /// </summary>

    [SerializeField]
    protected float health;
    [SerializeField]
    protected float attackPower;
    [SerializeField]
    protected float speed;

    protected int cost;

    [SerializeField]
    private bool isMoving = true;

    public virtual void MoveAcross()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public virtual void DealDamage(Collider other)
    {
        // deal damage to opponent's unit or base
        isMoving = false;

        Unit opponentUnit = other.gameObject.GetComponent<Unit>();
        
        health -= opponentUnit.attackPower * Time.deltaTime;
        //Debug.Log("Health: " + health);

        if (opponentUnit.health < 0)
        {
            isMoving = true;
        }

        if (health < 0)
        {
            //opponentUnit.isMoving = true;
            Destroy(gameObject);
        }
    }
}
