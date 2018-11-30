using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    InventoryManager IM; // Her laver vi en genvej til vores InventoryManager script så vi kan kalde de offentlige værdier i dette script

    public Text foodCounter; // Her definere vi at vi har en tekstbox som vi, i dette tilfælde, bruger til at holde styr på vores mad
    public Text stoneCounter; // Her definere vi at vi har en tekstbox som vi, i dette tilfælde, bruger til at holde styr på vores sten
    public Text treeCounter; // Her definere vi at vi har en tekstbox som vi, i dette tilfælde, bruger til at holde styr på vores træ

    public GameObject pauseMenu; // Her definere vi at vi skal bruge hvilket som helst form for GameObject så vi kan bruge nogle generelle funktioner på objektet

    public Slider healthBar; // Her definere vi at vi bruger en slider som vores liv. Vi har fjernet knappen inde i selve spillet så man ikke længere kan bruge slideren, men at den blot viser hvor meget liv man har
    public Slider energyBar; // Her definere vi at vi bruger en slider som vores energi bar. Vi har fjernet knappen inde i selve spillet så man ikke længere kan bruge slideren, men at den blot viser hvor meget energi man har tilbage

    public bool isPaused; // Her definere vi et flag i form af en boolean som vi bruger til at holde styr på om spillet er pauset

	void Start () // Denne funktion bliver kørt 1 gang lige ved starten af spillet
    {
        isPaused = false; // Her definere vi at vores flag er slået fra
        IM = FindObjectOfType<InventoryManager>(); // Her definere vi den genvej vi tidligere definerede og gør at vi kan kalde den igennem dette script med IM foran alle InventoryManagerens offentlige variabler
        healthBar.value = 1; // Her sætter vi livs-barens start værdi til at være dens maks værdi(1)
        energyBar.value = 10; // Her sætter vi energi-barens start værdi til at være dens maks værdi(10)
    }

	void Update () // Denne funktion bliver kørt 1 gang pr frame i spillet
    {
        foodCounter.text = "" + IM.foodCount; // Her sætter vi vores tekst til at være mængden af vores mad
        stoneCounter.text =  "" + IM.stoneCount; // Her sætter vi vores tekst til at være mængden af vores sten
        treeCounter.text = "" + IM.treeCount; // Her sætter vi vores tekst til at være mængden af vores træ

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) // Her tjekker den om vi har trykket på "Escape-knappen" og om vores spil ikke allerede er sat på pause
        {
            pauseMenu.SetActive(true); // Her sætter vi vores pause menu til at være aktiv, da den fra spilstart er sat til at være deaktiveret
            isPaused = true; // Her sætter vi vores flag til at være sandt
            Time.timeScale = 0; // Her sætter vi vores tid til at stå stille, dvs at man sætter spillet på pause
            Debug.Log("Paused"); // Her får vi en besked skrevet ud til konsolen for at sikre os at spillet er sat på pause
        }
        /*if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            Debug.Log("Unpaused");
        }*/
	}

    public void resumeGame() // Her definere vi en funktion som vi bruger til vores knap "Resume" som er i pause menuen
    {
        pauseMenu.SetActive(false); // Her sætter vi vores pause menu til at være inaktiv
        isPaused = false; // Her sætter vi vores flag til at være falsk igen
        Time.timeScale = 1; // Her sætter vi vores spil igang igen
    }

    public void exitApplication() // Her definere vi en funktion som vi bruger til vores knap "Exit to Desktop" som er i pause menuen
    {
            Application.Quit(); // Denne kode blok lukker vores spil ned
    }

    public void loadMenu() // Her definere vi en funktion som vi bruger til vores knap "Exit to Menu" som er i pause menuen
    {
        SceneManager.LoadScene(0); // Her beder vi vores scenemanager om at indlæse den første scene som er i vores level index. 
    }

    public void loadLevel() // Her definere vi en funktion som vi bruger til vores knap "Start Game" som er i start menuen
    {
        SceneManager.LoadScene(1); // Her beder vi vores scenemanager om at indlæse den anden scene som er i vores level index. 
    }
}
