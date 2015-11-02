using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Cube;
    public int nSpawnPoint;
    public int nSpawns;
    public int holdSpawn;
    public int randomCheck;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        // Generates random number for GameObjects to spawn on
        nSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Checks if the previous random number was used
        if (nSpawnPoint == randomCheck)
        {
            // If it was, rerandomize the value
            nSpawnPoint = Random.Range(0, spawnPoints.Length);
        }

        // Loops 3 times so that 3 Objects can spawn
        else if (nSpawns < 3)
        {
            // Create an instance of the cube prefab at the randomly selected spawn point's position and rotation.
            Instantiate(Cube, spawnPoints[nSpawnPoint].position, spawnPoints[nSpawnPoint].rotation);
            nSpawns++;
        }

        // Set values so that we can check for the random number
        holdSpawn = nSpawnPoint;
        randomCheck = holdSpawn;
    }
}

