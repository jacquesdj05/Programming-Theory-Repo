using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    private float zBound = 6.5f;

    public int currentZone { get; private set; }

    public int credits;

    // Start is called before the first frame update
    void Start()
    {
        credits = 100;

        InvokeRepeating("IncreaseCredits", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerMovement();
    }

    // Move player based on up- and down-arrow presses
    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }

    // Constrain the player from moving beyond the top and bottom of the screen
    void ConstrainPlayerMovement()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawn_Zone"))
        {
            if (other.gameObject.name == "Spawn Zone 1")
            {
                currentZone = 1;
            }
            else if (other.gameObject.name == "Spawn Zone 2")
            {
                currentZone = 2;
            }
            else if (other.gameObject.name == "Spawn Zone 3")
            {
                currentZone = 3;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Spawn_Zone"))
        {
            currentZone = 0;
        }
    }

    private void IncreaseCredits()
    {
        int inceaseAmount = 5;

        credits += inceaseAmount;
    }
}
