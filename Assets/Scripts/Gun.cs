using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public Rigidbody gun;
    public float speed;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bullet = Instantiate(gun, transform.position, transform.rotation) as Rigidbody;
            bullet.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
	}
}
