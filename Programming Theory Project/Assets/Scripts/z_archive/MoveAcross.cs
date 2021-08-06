using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcross : MonoBehaviour
{
    public float speed = 5f;

    private float xBound = 12f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            speed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Unit"))
        {
            playerUnitTriggerActions(other);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            enemyTriggerActions(other);
        }
        
    }

    void playerUnitTriggerActions(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Unit has collided with enemy");
            //speed = 0;
        }

        if (other.CompareTag("Enemy_Zone"))
        {
            Destroy(gameObject);
        }
    }

    void enemyTriggerActions(Collider other)
    {
        if (other.CompareTag("Player_Zone"))
        {
            Destroy(gameObject);
        }
    }    
}
