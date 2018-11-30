using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    InventoryManager IM; // Her laver vi en genvej til vores InventoryManager script så vi kan kalde de offentlige værdier i dette script
    UIManager UM; // Her laver vi en genvej til vores UIManager script så vi kan kalde de offentlige værdier i dette script

    [SerializeField] private int movementSpeed; // Denne private integer er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil
    [SerializeField] private bool isRunning; // Dette private flag er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil
    [SerializeField] private bool healthLost; // Dette private flag er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil
    [SerializeField] private bool foodLost; // Dette private flag er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil
    [SerializeField] private bool foodRecover; // Dette private flag er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil
    [SerializeField] private bool energyLost; // Dette private flag er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil

    //public bool isJumping;

    private int sprintSpeed = 1; // Her sætter vi hvor hurtigt man skal løbe fra start af i en lukket variabel som kun kan tilgås fra dette script
    private float healthLoss = 0.05f; // Her sætter vi hvor meget man skal tabe liv med i en lukket variabel som kun kan tilgås fra dette script


    Camera CC; // Her definere vi at vi har et kamera med genvejsnavnet CC


	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>(); // Her definere vi den genvej vi tidligere definerede og gør at vi kan kalde den igennem dette script med IM foran alle InventoryManagerens offentlige variabler
        UM = FindObjectOfType<UIManager>(); // Her definere vi den genvej vi tidligere definerede og gør at vi kan kalde den igennem dette script med UM foran alle UIManagerens offentlige variabler

        //isJumping = false;
        energyLost = false; // Her sætter vi start værdien af vores flag til at være falsk
        foodRecover = true; // Her sætter vi start værdien af vores flag til at være sandt
        foodLost = false; // Her sætter vi start værdien af vores flag til at være falsk
        healthLost = false; // Her sætter vi start værdien af vores flag til at være falsk
        isRunning = false; // Her sætter vi start værdien af vores flag til at være falsk
        CC = Camera.main; // Her giver vi vores hoved kamera et genvejsnavn
	}
	

	void Update () // Denne metode bliver kørt 1 gang per frame 
    {

        if(UM.healthBar.value == 0) // Hvis man ikke har mere liv bliver kodeblokken kørt
        {
            Application.Quit(); // Denne funktion lukker vores aktuelle spil ned
        }

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
        if (IM.foodCount == 0) // Denne kodeblok bliver kun kørt hvis vi har 0 i mad
        {
            if((int)Time.time >= 1 && (int)Time.time % 2 == 0 && !healthLost) // Denne if løkke bliver kørt hver andet sekund samt hvis vi ikke er i gang med at tabe liv
            {
                UM.healthBar.value -= healthLoss; // Her trækker den en predefineret værdi fra vores aktuelle liv
                healthLost = true; // Her sætter den vores tab af liv flag til at være sand
            }
            else if((int)Time.time % 2 == 1 && healthLost) // Denne if løkke bliver kørt hver gang der er et ulige sekund og vi er i gang med at tabe liv
            {
                healthLost = false; // Her sætter den vores tab af liv flag til at være falsk
            }
        }
        else if(IM.foodCount >= 1) // Denne kodeblok bliver kørt hvis vi har 1 eller mere mad
        {
            if((int)Time.time >= 1 && (int)Time.time % 10 == 0 && !foodLost) // Denne if løkke bliver kørt hver 10. sekund samt hvis vi ikke er igang med at tab mad
            {
                IM.foodCount--; // Her trækker den 1 mad fra vores aktuelle mængde af mad
                foodLost = true; // Her sætter den vores tab af mad flag til at være sandt
            }
            else if((int)Time.time % 10 == 1 && foodLost) // Denne if løkke bliver kørt hvert niende sekund samt hvis vi er igang med at tab mad
            {
                foodLost = false; // Her sætter den vores tab af mad flag til at være falsk
            }
            if((int)Time.time % 2 == 0 && UM.healthBar.value < 1 && foodRecover) // Denne if løkker bliver kørt hver andet sekund samt hvis vi er i gang med at regnerere liv
            {
                UM.healthBar.value += 0.1f; // Her lægger den 0.1 til vores aktuelle liv
                foodRecover = false; // Her sætter den vore regenerering af mad flag til at være falsk
            }
            else if((int)Time.time % 2 == 1 && !foodRecover) // Denne if løkke bliver kørt hver gang vi har et ulige sekund og vi ikke allerede er igang med at regenerere mad
            {
                foodRecover = true; // Her sætter den vores regenerering af mad flag til at være sand
            }
        }

        if(UM.energyBar.value == 0) // Her tjekker den om vi er løbet tør for energi
        {
            energyLost = true; // Her sætter den vores regenerering af energi flag til at være sandt
        }
        else if(UM.energyBar.value == 10) // Her tjekker den om vi har en fuld energi bar
        {
            energyLost = false; // Her sætter den vores regenerering af energi flag til at være falsk
        }

        //Denne kodeblok er til at tjekke om man løber eller om man går
        if (Input.GetKey(KeyCode.LeftShift) && UM.energyBar.value != 0 && !energyLost) // Her tjekker den om vi holder den venstre skift knap nede samt om vi har noget energi tilbage og om vi ikke er igang med at regenere fra at være løbet tør for energi
        {
            sprintSpeed = 3; // Her sætter den vores sprint hastighed til at være 3 hvilket gør at vi bevæger os 3 gange hurtigere aka at man løber
            isRunning = true; // Her sætter den vores løbe flag til at være sandt
        }
        else // Hvis ikke den ovenstående if løkke er sand bliver vores else kodeblok kørt i stedet
        {
            sprintSpeed = 1; // Her sætter den vores sprint hastighed til at være 1, hvilket gør at man ikke længere løber
            isRunning = false; // Her sætter den vores løbe flag til at være falsk
        }

        if(isRunning) // Her tjekker den om vi er igang med at løbe, og hvis vi løber bliver resten af kodeblokken kørt
        {
            UM.energyBar.value -= 0.05f; // Her trækker den 0.05 fra vores aktuelle energi bar værdi 
        }
        else if(!isRunning) // Her tjekker den om vi er igang med at løbe, og hvis vi kun går så bliver resten af kodeblokken kørt
        {
            UM.energyBar.value += 0.1f; // Her lægger den 0.1 til vores energi bar værdi
        }

        if (!UM.isPaused) // Her tjekker den om vores spil er igang eller sat på pause
        {
            //Denne kodeblok er hele bevægelsen for vores karakter
            CC.transform.position = new Vector3(transform.position.x, transform.position.y, CC.transform.position.z); // Her sætter vi vores kamera til at følge vores spiller ved at sætte kameraets x og y koordinater til de samme som vores spiller
            transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed * sprintSpeed, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed * sprintSpeed, 0f); // Her tilføjer den bevægelse til vores spiller alt afhængigt af hvilken knap vi trykker på
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // Her tager den vores mus' position og trækker den fra vores kameras aktuelle position og derefter gemmer den det i en variabel
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // Her tager den og udregner tangenten til vores mus ud fra den variabel vi lavede i linjen ovenfors x og y koordinater. Det omdanner den så fra radianer til grader og gemmer det i en ny variabel
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); // Her sætter vi vores karakters rotation til at være resultatet af linjen ovenfor samt sætter det til at være om z-aksen
        }
    }


    void OnCollisionEnter2D(Collision2D col) // Denne kodeblok bliver kørt hvis vi collidere med en anden collider.
    {
        if(col.gameObject.tag == "Stone Pickup") // Her tjekker den om det objekt vi er kolideret med har tagget "Stone Pickup"
        {
            Destroy(col.gameObject); // Her fjerner den vores pickup fra "verdenen"
            IM.stoneCount++; // Her bliver der lagt 1 til vores aktuelle mængde af sten
        }

        if(col.gameObject.tag == "Food Pickup") // Her tjekker den om det objekt vi er kolideret med har tagget "Food Pickup"
        {
            Destroy(col.gameObject); // Her fjerner den vores pickup fra "verdenen"
            IM.foodCount++; // Her bliver der lagt 1 til vores aktuelle mængde af mad
        }
    }   
}