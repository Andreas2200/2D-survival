using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private int movementSpeed;

    Camera CC;


	// Use this for initialization
	void Start ()
    {
        CC = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CC.transform.position = new Vector3(transform.position.x, transform.position.y, CC.transform.position.z);
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed,0f);
	}
}
