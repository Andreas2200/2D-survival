using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    InventoryManager IM;

    [SerializeField] private int movementSpeed;
    [SerializeField] private bool isRunning;
    
    private int sprintSpeed = 1;

    Camera CC;


	// Use this for initialization
	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>();

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
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed * sprintSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed * sprintSpeed,0f);
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Stone Pickup")
        {
            Destroy(col.gameObject);
            IM.stoneCount++;
        }
    }   
}