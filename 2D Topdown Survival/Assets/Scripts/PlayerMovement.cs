using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private int movementSpeed;



	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed,0f);
	}
}
