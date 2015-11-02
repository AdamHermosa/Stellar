using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public float speed = 2.0f;
    public float rotateSpeed = 3.0f;

    public Renderer enemy;

	// Use this for initialization
	void Start ()
    {
        enemy = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemy.isVisible)
        {

        }

        else
        {
            MoveEnemy();
        }

    }
    
    void MoveEnemy()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        float rotate = Mathf.Min(rotateSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotate);
    }

    void OnTriggerEnter (Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Application.LoadLevel("GameOver");
        }
    }
}
