using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    InventoryManager IM;
    UIManager UM;

    [SerializeField] private int movementSpeed;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool healthLost;
    [SerializeField] private bool foodLost;
    [SerializeField] private bool foodRecover;
    
    private int sprintSpeed = 1;
    private float healthLoss = 0.1f;


    Camera CC;


	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>();
        UM = FindObjectOfType<UIManager>();

        foodRecover = true;
        foodLost = false;
        healthLost = false;
        isRunning = false;
        CC = Camera.main;
	}
	

	void Update ()
    {

        if (IM.foodCount == 0)
        {
            if((int)Time.time >= 1 && (int)Time.time % 2 == 0 && !healthLost)
            {
                UM.healthBar.value -= healthLoss;
                healthLost = true;
            }
            else if((int)Time.time % 2 == 1 && healthLost)
            {
                healthLost = false;
            }
        }
        else if(IM.foodCount >= 1)
        {
            if((int)Time.time >= 1 && (int)Time.time % 10 == 0 && !foodLost)
            {
                IM.foodCount--;
                foodLost = true;
            }
            else if((int)Time.time % 10 == 1 && foodLost)
            {
                foodLost = false;
            }
            if((int)Time.time % 2 == 0 && UM.healthBar.value < 1 && foodRecover)
            {
                UM.healthBar.value += 0.1f;
                foodRecover = false;
            }
            else if((int)Time.time % 2 == 1 && !foodRecover)
            {
                foodRecover = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
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

        if(col.gameObject.tag == "Food Pickup")
        {
            Destroy(col.gameObject);
            IM.foodCount++;
        }
    }   
}