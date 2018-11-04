using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInstantiation : MonoBehaviour {
    
    public Transform[] fire_locations;
    public GameObject firePrefab;

    private float fire_timer;
    private int fireIndex;
    public List<int> current_locations = new List<int>();
    private Vector2 fire_placement;

    // Use this for initialization
    void Start()
    {
        SpawnFire();
        fire_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fire_timer++;

        if(fire_timer % 3600 == 0 && current_locations.Count < fire_locations.Length)
        {
            SpawnFire();
        }
    }

    /// <summary>
    /// This function get's an index that isnt being used by other enemies.
    /// It stores an integer into a List<int> current_locations.
    /// It makes sure to return a value that isnt within the List.
    /// </summary>
    /// <returns>
    /// An integer, from 0 - waypoints.length (0-14)
    /// </returns>
    private int GetIndex()
    {
        int index = Random.Range(0, fire_locations.Length);  // Declare and initialize index to be a random number from 0-14 (waypoint.length)

        // while loop: Validation method that if the integer "index" is already in the List "current_locations" then,
        // try for a new random integer, until one is not located in that list.
        while (current_locations.Contains(index))
        {
            index = Random.Range(0, fire_locations.Length);
        }

        current_locations.Add(index);   // Add integer to List

        return index;                   // Return integer
    }

    /// <summary>
    /// This function will spawn all of the plushies at the start of the game
    /// </summary>
    void SpawnFire()
    {                                                                  
        fireIndex = GetIndex();
        fire_placement = new Vector3(fire_locations[fireIndex].position.x, fire_locations[fireIndex].position.y, 0);
        Instantiate(firePrefab, fire_placement, Quaternion.identity);
    }
}
