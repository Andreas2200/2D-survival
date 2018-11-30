using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {


    [SerializeField] private GameObject player;

    public int foodCount;
    public int stoneCount;
    public int treeCount;


	void Start ()
    {
        foodCount = 1;
        stoneCount = 0;
        treeCount = 0;

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
		
	}
}
