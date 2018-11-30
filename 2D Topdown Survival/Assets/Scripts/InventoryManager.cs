using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {


    [SerializeField] private GameObject player; // Denne private GameObject er gjort synlig i vores Unity-editor ved hjælp af "[SerializeField]" som vi bruger til at debugge vores spil

    public int foodCount; // Her definere vi en offentlig integer som holder styr på vores mad
    public int stoneCount; // Her definere vi en offentlig integer som holder styr på vores sten
    public int treeCount; // Her definere vi en offentlig integer som holder styr på vores træ


    void Start () // Denne funktion bliver kørt 1 gang lige ved starten af spillet
    {
        foodCount = 1; // Her sætter vores start værdi for vores mad
        stoneCount = 0; // Her sætter vores start værdi for vores sten
        treeCount = 0; // Her sætter vores start værdi for vores træ

        player = GameObject.FindGameObjectWithTag("Player"); // Her sætter vi automatisk at vores "player" objekt er det GameObject med tagget "Player"
	}
}
