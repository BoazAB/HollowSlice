using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{

    //Laat de aanpassende snelheid zien
    [SerializeField]
    float health, maxHealth = 1f;

    //Array of waypoints to walk from one to the other
    [SerializeField]
    private Transform[] waypoints;


    //Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 3f;

    //Index of current waypoint from which Enemy walks to the next one

    private int waypointIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
        Debug.Log("Start");

        // Houdt health op maxHealth elke keer wanneer het spel begint
        health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        //Move Enemy
        Move();
        Debug.Log("Update");
    }

    //Method that actually makes the Enemy walk
    private void Move()
    {
        //If Enemy didn't reach last waypoint it can move
        //If Enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {
            //Move Enemy from current waypoint to the next one
            // Using MoveTowards method
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            //If Enemy reaches position of waypoints he walked towards
            //Then waypointIndex is increased by 1
            //And Enemy starts to walk to the next waypoint
            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex+= 1;
            }
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
        Debug.Log("Move");
    }

    public void TakeDamage(float damageAmount)
    {
        //Health is being reduced
        health -= damageAmount;

        //enemy will be destroyed if health reaches 0
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
