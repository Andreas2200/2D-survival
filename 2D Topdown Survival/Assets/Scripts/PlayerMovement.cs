using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private int movementSpeed;
    [SerializeField] private bool isRunning;

    private int sprintSpeed = 1;

    Camera CC;


	// Use this for initialization
	void Start ()
    {
        isRunning = false;
        CC = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        if(isRunning)
        {
            sprintSpeed = 3;
        }
        else if(!isRunning)
        {
            sprintSpeed = 1;
        }

        CC.transform.position = new Vector3(transform.position.x, transform.position.y, CC.transform.position.z);
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed * sprintSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed,0f);
    }
}
