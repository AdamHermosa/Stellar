using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collectable : MonoBehaviour
{
    public Dictionary<string, int> Collectables;
    public Transform[] collectableSpawn;
    public GameObject Sphere;

    public string[] spawnNames;
    public int[] collectableCount;
    public int nSpawns;

    // Use this for initialization
    void Start ()
    {
        Collectables = new Dictionary<string, int>();

        foreach (GameObject items in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            if (Collectables.ContainsKey(items.name))
            {
                Collectables[items.name] += 1;
            }

            else
            {
                Collectables.Add(items.name, 1);
            }
        }

        spawnNames = new string[Collectables.Keys.Count];

        collectableCount = new int[Collectables.Values.Count];

        Collectables.Keys.CopyTo(spawnNames, 0);
        Collectables.Values.CopyTo(collectableCount, 0);

        for (int i = 0; i < spawnNames.Length; i++)
        {
            Debug.Log(spawnNames[i]);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (nSpawns < 1)
        {
            for (int i = 0; i < spawnNames.Length; i++)
            {
                Instantiate(Sphere, collectableSpawn[i].position, collectableSpawn[i].rotation);
                nSpawns++;
            }
        }
	}

}
