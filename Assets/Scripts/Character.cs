﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Makes sure that the CharacterController Component is added to what ever the script is attached to
[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {

	// Variables to control speeds for movements
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 9.81f;
    public bool doubleJump = false;
    private float jumpVel = 0;

    // Used by Move() to move the player in a certain direction
    Vector3 moveDirection = Vector3.zero;

	// Used to select if Move() or SimpleMove() is used
	// Move() == 1
	// SimpleMove() == 0
    public int type;

	// Reference to controller used to move the player
    public CharacterController cc;
    public GameObject player;

    public int score;

    // Use this for initialization
    void Start ()
    {
	    // Grab a component and keep a reference to it
        cc = GetComponent<CharacterController>();
       
		// Check if the component exists
		if (!cc)
            Debug.Log("CharacterController does not exist.");
        OnGUI();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float rotateSpeedX = Input.GetAxis("Mouse X");

        // Use the up and down keys to move the player along the Z-axis
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Rotate the transform the Script is awttached to using to left and right keys
        transform.Rotate(0, rotateSpeedX, 0);
        // Translates the local coordinates to world coordinates
        moveDirection = transform.TransformDirection(moveDirection);
        // Make the speed more than 1
        moveDirection *= speed;

        // Checks when the player presses the jump button
        if (Input.GetButtonDown("Jump"))
        {
            // Checks if the character is grounded
            if (cc.isGrounded)
            {
                // Applies a jumpSpeed to allow the character to jump
                jumpVel = jumpSpeed;
                // Toggles a double jump for the character
                doubleJump = true;
            }

            // Checks when the player is in the air
            else
            {
                // Checks if the double jump toggle was triggered
                if (doubleJump == true)
                {
                    // Resets the double jump trigger
                    doubleJump = false;
                    // Applies a jumpSpeed to allow the character's second jump
                    jumpVel = jumpSpeed;
                }
            }
        }

        // Applies gravity to the jumpVel variable
        jumpVel -= gravity * Time.deltaTime;
        // Applies jumpVel in the y direction to move the player downwards 
        moveDirection.y = jumpVel;
        // Applies the Move action using the direction which had speed applied
        cc.Move(moveDirection * Time.deltaTime);

	} // closes Update

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Collectable")
        {
            Destroy(c.gameObject);
            score += 50;
            OnGUI();
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: "+score);
    }
}
