using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.name == "Cube")
        {
            Destroy(c.gameObject);
        }
    }
}
