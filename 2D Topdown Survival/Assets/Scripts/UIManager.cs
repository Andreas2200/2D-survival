using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    InventoryManager IM;

    public Text foodCounter;
    public Text stoneCounter;
    public Text treeCounter;

    public Slider healthBar;
    public Slider energyBar;

	void Start ()
    {
        IM = FindObjectOfType<InventoryManager>();
        healthBar.value = 1;
        energyBar.value = 10;
    }
	

	void Update ()
    {
        foodCounter.text = "" + IM.foodCount;
        stoneCounter.text =  "" + IM.stoneCount;
        treeCounter.text = "" + IM.treeCount;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
