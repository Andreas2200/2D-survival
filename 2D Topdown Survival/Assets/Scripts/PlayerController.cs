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
    [SerializeField] private bool energyLost;

    //public bool isJumping;
    
    private int sprintSpeed = 1;
    private float healthLoss = 0.05f;


    Camera CC;


	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>();
        UM = FindObjectOfType<UIManager>();

        //isJumping = false;
        energyLost = false;
        foodRecover = true;
        foodLost = false;
        healthLost = false;
        isRunning = false;
        CC = Camera.main;
	}
	

	void Update ()
    {
        //Denne kodeblok styrer vores karakters hoppe funktion
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Debug.Log(isJumping);
            if(transform.rotation.z > 0.0000001f && transform.rotation.z < 0.7f)
            {
                Debug.Log("Hej 1");
                transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f);
            }
            if(transform.rotation.z < -0.0000001f && transform.rotation.z > -0.7f)
            {
                Debug.Log("Hej 2");
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f);
            }
            if(transform.rotation.z < -0.7f && transform.rotation.z > -0.999999f)
            {
                Debug.Log("Hej 3");
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f);
            }
            if(transform.rotation.z > 0.7f && transform.rotation.z < 0.999999f)
            {
                Debug.Log("Hej 4");
                transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f);
            }

        }
        else
        {
            //isJumping = false;
        }*/

        //Denne kodeblok er til styringen af vores liv
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

        if(UM.energyBar.value == 0)
        {
            energyLost = true;
        }
        else if(UM.energyBar.value == 10)
        {
            energyLost = false;
        }

        //Denne kodeblok er til at tjekke om man løber eller om man går
        if (Input.GetKey(KeyCode.LeftShift) && UM.energyBar.value != 0 && !energyLost)
        {
            sprintSpeed = 3;
            isRunning = true;
        }
        else
        {
            sprintSpeed = 1;
            isRunning = false;
        }

        if(isRunning)
        {
            UM.energyBar.value -= 0.05f;
        }
        else if(!isRunning)
        {
            UM.energyBar.value += 0.1f;
        }

        if (!UM.isPaused)
        {
            //Denne kodeblok er hele bevægelsen for vores karakter
            CC.transform.position = new Vector3(transform.position.x, transform.position.y, CC.transform.position.z);
            transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed * sprintSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed * sprintSpeed, 0f);
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
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